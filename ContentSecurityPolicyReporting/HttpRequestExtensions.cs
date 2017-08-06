using System.IO;
using Microsoft.AspNetCore.Http;

namespace ContentSecurityPolicyReporting
{
    internal static class HttpRequestExtensions
    {
        private const string PostMethod = "POST";

        public static bool IsPost(this HttpRequest httpRequest)
        {
            return httpRequest.Method.ToUpperInvariant() == PostMethod;
        }

        public static bool IsMappedEndpoint(this HttpRequest httpRequest, string endPoint)
        {
            return httpRequest.Path.ToString().EndsWith(endPoint);
        }

        public static string ReadRequestBody(this HttpRequest httpRequest)
        {
            return new StreamReader(httpRequest.Body).ReadToEnd();
        }
    }
}
