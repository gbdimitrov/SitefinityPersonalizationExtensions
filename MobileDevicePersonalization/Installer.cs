using System;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Personalization.Impl;
using Telerik.Sitefinity.Personalization.Impl.Configuration;
using Telerik.Sitefinity.Services;

namespace MobileDevicePersonalization
{
    public class Installer
    {
        /// <summary>
        /// This is the actual method that is called by ASP.NET even before application start.
        /// </summary>
        public static void PreApplicationStart()
        {
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
        }

        /// <summary>
        /// Handles the ApplicationStart event of the SystemManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSampleWorker);
            SystemManager.RunWithElevatedPrivilege(worker);
        }

        /// <summary>
        /// Creates the sample worker.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private static void CreateSampleWorker(object[] parameters)
        {
            if (IsPersonalizationModuleInstalled())
            {
                AddVirtualPathToEmbeddedRes();

                CreateCriteria();

                RegisterCriteria();
            }
        }

        /// <summary>
        /// Checks if the Personalization module is install in the Sitefinity application
        /// </summary>
        /// <returns></returns>
        private static bool IsPersonalizationModuleInstalled()
        {
            return SystemManager.ApplicationModules != null &&
                SystemManager.ApplicationModules.ContainsKey(PersonalizationModule.ModuleName) &&
                !(SystemManager.ApplicationModules[PersonalizationModule.ModuleName] is InactiveModule);
        }

        /// <summary>
        /// Adds the virtual path to embedded resource.
        /// </summary>
        private static void AddVirtualPathToEmbeddedRes()
        {
            Res.RegisterResource<MobileDevicePersonalizationResources>();

            var virtualPathConfig = Config.Get<VirtualPathSettingsConfig>();
            if (!virtualPathConfig.VirtualPaths.Contains(Installer.virtualPath + "*"))
            {
                var pathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = Installer.virtualPath + "*",
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "MobileDevicePersonalization"
                };
                virtualPathConfig.VirtualPaths.Add(pathConfig);
                ConfigManager.GetManager().SaveSection(virtualPathConfig);
                SystemManager.RestartApplication("ConfigChange");
            }

        }

        /// <summary>
        /// Creates the criteria
        /// </summary>
        private static void CreateCriteria()
        {
            var personalizationConfig = Config.Get<PersonalizationConfig>();
            if (!personalizationConfig.Criteria.Contains("MobileDevice"))
            {
                CriterionElement ageCriterion = new CriterionElement(personalizationConfig.Criteria)
                {
                    Name = "MobileDevice",
                    Title = "MobileDevice",
                    ResourceClassId = typeof(MobileDevicePersonalizationResources).Name,
                    CriterionEditorUrl = "MobileDevicePersonalization.MobileDeviceEditor.ascx",
                    ConsoleCriterionEditorUrl = "MobileDevicePersonalization.MobileDeviceConsoleEditor.ascx",
                    CriterionVirtualPathPrefix = Installer.virtualPath
                };
                personalizationConfig.Criteria.Add(ageCriterion);
            }
        }

        /// <summary>
        /// Register the evaluator for the criteria
        /// </summary>
        private static void RegisterCriteria()
        {
            ObjectFactory.Container.RegisterType(
                typeof(ICriterionEvaluator),
                typeof(MobileDeviceEvaluator),
                "MobileDevice",
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor());
        }

        #region Private members & constants

        private static readonly string virtualPath = "~/SFMobileDevicePersonalization/";

        #endregion
    }
}
