using Telerik.Sitefinity.Localization;

namespace DemandbasePersonalization
{
    [ObjectInfo(typeof(DemandbasePersonalizationResources), Title = "DemandbasePersonalizationResourcesTitle", Description = "DemandbasePersonalizationResourcesDescription")]
    public class DemandbasePersonalizationResources : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemandbasePersonalizationResources"/> class.
        /// </summary>
        public DemandbasePersonalizationResources()
        {
        }

        /// <summary>
        /// word: Demandbase.
        /// </summary>
        [ResourceEntry("Demandbase",
            Value = "Demandbase",
            Description = "word: Demandbase",
            LastModified = "2018/02/07")]
        public string Demandbase
        {
            get { return this["Demandbase"]; }
        }

        /// <summary>
        /// word: Is.
        /// </summary>
        [ResourceEntry("Is",
            Value = "Is",
            Description = "word: Is",
            LastModified = "2018/02/07")]
        public string Is
        {
            get { return this["Is"]; }
        }

        /// <summary>
        /// phrase: Demandbase Personalization Resources.
        /// </summary>
        [ResourceEntry("DemandbasePersonalizationResourcesTitle",
            Value = "Demandbase Personalization Resources",
            Description = "phrase: Demandbase Personalization Resources",
            LastModified = "2018/02/07")]
        public string DemandbasePersonalizationResourcesTitle
        {
            get { return this["DemandbasePersonalizationResourcesTitle"]; }
        }

        /// <summary>
        /// phrase: Demandbase Personalization Resources.
        /// </summary>
        [ResourceEntry("DemandbasePersonalizationResourcesDescription",
            Value = "Demandbase Personalization Resources",
            Description = "phrase: Demandbase Personalization Resources",
            LastModified = "2018/02/07")]
        public string DemandbasePersonalizationResourcesDescription
        {
            get { return this["DemandbasePersonalizationResourcesDescription"]; }
        }

        /// <summary>
        /// phrase: Demandbase attribute.
        /// </summary>
        [ResourceEntry("DemandbaseAttribute",
            Value = "Demandbase attribute",
            Description = "phrase: Demandbase attribute",
            LastModified = "2018/02/07")]
        public string DemandbaseAttribute
        {
            get { return this["DemandbaseAttribute"]; }
        }

        /// <summary>
        /// word: Equals.
        /// </summary>
        [ResourceEntry("Equals",
            Value = "Equals",
            Description = "word: Equals",
            LastModified = "2018/02/07")]
        public string Equals
        {
            get { return this["Equals"]; }
        }

        /// <summary>
        /// word: Contains.
        /// </summary>
        [ResourceEntry("Contains",
            Value = "Contains",
            Description = "word: Contains",
            LastModified = "2018/02/07")]
        public string Contains
        {
            get { return this["Contains"]; }
        }

        /// <summary>
        /// phrase: Ends with.
        /// </summary>
        [ResourceEntry("EndsWith",
            Value = "Ends with",
            Description = "phrase: Ends with",
            LastModified = "2018/02/07")]
        public string EndsWith
        {
            get { return this["EndsWith"]; }
        }

        /// <summary>
        /// phrase: Starts with.
        /// </summary>
        [ResourceEntry("StartsWith",
            Value = "Starts with",
            Description = "phrase: Starts with",
            LastModified = "2018/02/07")]
        public string StartsWith
        {
            get { return this["StartsWith"]; }
        }


    }
}
