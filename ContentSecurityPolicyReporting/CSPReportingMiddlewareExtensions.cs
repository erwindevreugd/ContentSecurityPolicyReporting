using Microsoft.AspNetCore.Builder;

namespace ContentSecurityPolicyReporting
{
    public static class CSPReportingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCSPReporting(this IApplicationBuilder applicationBuilder, string endPoint)
        {
            return applicationBuilder.UseMiddleware<CSPReportingMiddleware>(endPoint);
        }
    }
}
