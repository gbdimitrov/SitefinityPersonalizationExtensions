using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;

namespace DemandbasePersonalization
{
    public class DemadnbaseAttributeEvaluator : ICriterionEvaluator
    {
        #region Properties
        
        protected virtual IPAddress VisitorIP
        {
            get
            {
                var result = this.GetIpAddress(SystemManager.CurrentHttpContext.Request);
                if (result != null)
                {
                    return result;
                }

                return IPAddress.None;
            }
        }

        #endregion

        #region ICriterionEvaluator members

        public bool IsMatch(string settings, IPersonalizationTestContext testContext)
        {
            if (string.IsNullOrEmpty(settings))
                return false;

            var serializer = new JavaScriptSerializer();
            var fieldSettings = serializer.Deserialize<FieldSettings>(settings);

            var fieldValue = string.Empty;

            if (testContext.IsInTestMode)
            {
                if (fieldSettings.FieldName.Equals(testContext["demandbaseAttributeName"], StringComparison.OrdinalIgnoreCase))
                    fieldValue = testContext["demandbaseAttributeValue"];
                else
                    return false;
            }
            else
            {
                var demandbaseJObject = SystemManager.CurrentHttpContext.Items["demandbaseJObject"] as JObject;

                if (demandbaseJObject == null)
                {
                    var client = new HttpClient();
                    var url = string.Concat(Config.Get<DemandbasePersonalizationConfig>().DemandbaseAPIUrl, "?key=", Config.Get<DemandbasePersonalizationConfig>().DemandbaseAPIKey, "&query=", this.VisitorIP.ToString());

                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        demandbaseJObject = JObject.Parse(responseString);
                        SystemManager.CurrentHttpContext.Items["demandbaseJObject"] = demandbaseJObject;
                    }
                }

                if (demandbaseJObject != null)
                {
                    var fieldAttribute = demandbaseJObject.Properties().FirstOrDefault(p => p.Name.Equals(fieldSettings.FieldName, StringComparison.OrdinalIgnoreCase));
                    if (fieldAttribute != null)
                        fieldValue = fieldAttribute.Value.ToString();
                }
            }

            switch (fieldSettings.ComparisonRule)
            {
                case "equals":
                    return fieldValue.Equals(fieldSettings.FieldValue, StringComparison.OrdinalIgnoreCase);
                case "contains":
                    return fieldValue.IndexOf(fieldSettings.FieldValue, StringComparison.OrdinalIgnoreCase) >= 0;
                case "startswith":
                    return fieldValue.StartsWith(fieldSettings.FieldValue, StringComparison.OrdinalIgnoreCase);
                case "endswith":
                    return fieldValue.StartsWith(fieldSettings.FieldValue, StringComparison.OrdinalIgnoreCase);
                default:
                    break;
            }

            return false;
        }
        #endregion

        #region Private members

        private IPAddress GetIpAddress(HttpRequestBase request)
        {
            IPAddress address = null;

            if (IPAddress.TryParse(request.Headers["CLIENT-IP"], out address))
            {
                return address;
            }
            else if (request.Headers["X-FORWARDED-FOR"] != null)
            {
                // If the X-FORWARDED-FOR header contains one or more ips - get the first one
                var ips = request.Headers["X-FORWARDED-FOR"].Split(',');
                var ip = ips[0].Trim();
                if (IPAddress.TryParse(ip, out address))
                    return address;
            }

            if (IPAddress.TryParse(request.Headers["X-FORWARDED"], out address))
            {
                return address;
            }
            else if (IPAddress.TryParse(request.Headers["X-CLUSTER-CLIENT-IP"], out address))
            {
                return address;
            }
            else if (IPAddress.TryParse(request.Headers["FORWARDED-FOR"], out address))
            {
                return address;
            }
            else if (IPAddress.TryParse(request.Headers["FORWARDED"], out address))
            {
                return address;
            }
            else if (IPAddress.TryParse(request.UserHostAddress, out address))
            {
                return address;
            }

            return null;
        }

        private class FieldSettings
        {
            public string FieldName { get; set; }

            public string FieldValue { get; set; }

            public string ComparisonRule { get; set; }
        }

        #endregion
    }
}
