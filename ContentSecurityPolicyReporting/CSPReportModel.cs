using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ContentSecurityPolicyReporting
{
    public class CSPReportModel : ICSPReport
    {
        private const string CSP_REPORT_TOKEN = "csp-report";

        [JsonProperty("document-uri")]
        public string DocumentUri { get; set; }
        [JsonProperty("referrer")]
        public string Refferer { get; set; }
        [JsonProperty("blocked-uri")]
        public string BlockedUri { get; set; }
        [JsonProperty("violated-directive")]
        public string ViolatedDirective { get; set; }
        [JsonProperty("original-policy")]
        public string OriginalPolicy { get; set; }
        [JsonProperty("disposition")]
        public string Disposition { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ICSPReport Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) { return null; };

            try
            {
                return JObject.Parse(json)?.SelectToken(CSP_REPORT_TOKEN)?.ToObject<CSPReportModel>() as ICSPReport;
            }
            catch
            {
                return null;
            }
        }
    }
}
