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

namespace DemandbasePersonalization
{
    public class Installer
    {
        public static void PreApplicationStart()
        {
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
        }

        private static void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSampleWorker);
            SystemManager.RunWithElevatedPrivilege(worker);
        }

        private static void CreateSampleWorker(object[] parameters)
        {
            if (IsPersonalizationModuleInstalled())
            {
                AddVirtualPathToEmbeddedRes();

                CreateCriteria();

                RegisterCriteria();
            }
        }

        private static bool IsPersonalizationModuleInstalled()
        {
            return SystemManager.ApplicationModules != null &&
                SystemManager.ApplicationModules.ContainsKey(PersonalizationModule.ModuleName) &&
                !(SystemManager.ApplicationModules[PersonalizationModule.ModuleName] is InactiveModule);
        }

        private static void AddVirtualPathToEmbeddedRes()
        {
            Res.RegisterResource<DemandbasePersonalizationResources>();
            Config.RegisterSection<DemandbasePersonalizationConfig>();

            var virtualPathConfig = Config.Get<VirtualPathSettingsConfig>();
            if (!virtualPathConfig.VirtualPaths.Contains(Installer.virtualPath + "*"))
            {
                var pathConfig = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = Installer.virtualPath + "*",
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "DemandbasePersonalization"
                };
                virtualPathConfig.VirtualPaths.Add(pathConfig);
                ConfigManager.GetManager().SaveSection(virtualPathConfig);
                SystemManager.RestartApplication("ConfigChange");
            }

        }

        private static void CreateCriteria()
        {
            var personalizationConfig = Config.Get<PersonalizationConfig>();
            if (!personalizationConfig.Criteria.Contains("Demandbase"))
            {
                CriterionElement ageCriterion = new CriterionElement(personalizationConfig.Criteria)
                {
                    Name = "Demandbase",
                    Title = "DemandbaseAttribute",
                    ResourceClassId = typeof(DemandbasePersonalizationResources).Name,
                    CriterionEditorUrl = "DemandbasePersonalization.DemandbaseAttributeEditor.ascx",
                    ConsoleCriterionEditorUrl = "DemandbasePersonalization.DemandbaseAttributeConsoleEditor.ascx",
                    CriterionVirtualPathPrefix = Installer.virtualPath
                };
                personalizationConfig.Criteria.Add(ageCriterion);
            }
        }

        private static void RegisterCriteria()
        {
            ObjectFactory.Container.RegisterType(
                typeof(ICriterionEvaluator),
                typeof(DemadnbaseAttributeEvaluator),
                "Demandbase",
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor());
        }

        #region Private members & constants

        private static readonly string virtualPath = "~/SFDemandbasePersonalization/";

        #endregion
    }
}
