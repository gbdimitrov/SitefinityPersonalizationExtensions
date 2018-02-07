using Telerik.Sitefinity.Localization;

namespace MobileDevicePersonalization
{
    [ObjectInfo(typeof(MobileDevicePersonalizationResources), Title = "MobileDevicePersonalizationResourcesTitle", Description = "MobileDevicePersonalizationResourcesDescription")]
    public class MobileDevicePersonalizationResources : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDevicePersonalizationResources"/> class.
        /// </summary>
        public MobileDevicePersonalizationResources()
        {
        }

        /// <summary>
        /// phrase: Mobile Device.
        /// </summary>
        [ResourceEntry("MobileDevice",
            Value = "Mobile Device",
            Description = "phrase: Mobile Device",
            LastModified = "2018/02/07")]
        public string MobileDevice
        {
            get { return this["MobileDevice"]; }
        }

        /// <summary>
        /// phrase: Is mobile device.
        /// </summary>
        [ResourceEntry("IsMobileDevice",
            Value = "Is mobile device",
            Description = "phrase: Is mobile device",
            LastModified = "2018/02/07")]
        public string IsMobileDevice
        {
            get { return this["IsMobileDevice"]; }
        }

        /// <summary>
        /// phrase: Is not a mobile device.
        /// </summary>
        [ResourceEntry("IsNotMobileDevice",
            Value = "Is not a mobile device",
            Description = "phrase: Is not a mobile device",
            LastModified = "2018/02/07")]
        public string IsNotMobileDevice
        {
            get { return this["IsNotMobileDevice"]; }
        }

        /// <summary>
        /// phrase: Mobile Device Personalization Resources.
        /// </summary>
        [ResourceEntry("MobileDevicePersonalizationResourcesTitle",
            Value = "Mobile Device Personalization Resources",
            Description = "phrase: Mobile Device Personalization Resources",
            LastModified = "2018/02/07")]
        public string MobileDevicePersonalizationResourcesTitle
        {
            get { return this["MobileDevicePersonalizationResourcesTitle"]; }
        }

        /// <summary>
        /// phrase: Mobile Device Personalization Resources.
        /// </summary>
        [ResourceEntry("MobileDevicePersonalizationResourcesDescription",
            Value = "Mobile Device Personalization Resources",
            Description = "phrase: Mobile Device Personalization Resources",
            LastModified = "2018/02/07")]
        public string MobileDevicePersonalizationResourcesDescription
        {
            get { return this["MobileDevicePersonalizationResourcesDescription"]; }
        }
    }
}
