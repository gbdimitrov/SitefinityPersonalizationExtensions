using System.Configuration;
using Telerik.Sitefinity.Configuration;

namespace DemandbasePersonalization
{
    public class DemandbasePersonalizationConfig : ConfigSection
    {
        [ConfigurationProperty("DemandbaseAPIUrl", DefaultValue = "https://api.demandbase.com/api/v2/ip.json", IsRequired = true)]
        public string DemandbaseAPIUrl
        {
            get
            {
                return (string)this["DemandbaseAPIUrl"];
            }
            set
            {
                this["DemandbaseAPIUrl"] = value;
            }
        }

        [ConfigurationProperty("DemandbaseAPIKey", DefaultValue = "", IsRequired = true)]
        public string DemandbaseAPIKey
        {
            get
            {
                return (string)this["DemandbaseAPIKey"];
            }
            set
            {
                this["DemandbaseAPIKey"] = value;
            }
        }
    }
}
