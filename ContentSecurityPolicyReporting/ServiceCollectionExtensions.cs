using Microsoft.Extensions.DependencyInjection;

namespace ContentSecurityPolicyReporting
{
    public static class ServiceCollectionExtensions
    {
        public static ICSPReportingBuilder AddCSPReporting(this IServiceCollection services, ICSPReportReceivedHandler handler)
        {
            services.AddSingleton(typeof(ICSPReportReceivedHandler), handler);

            return new CSPReportingBuilder(services);
        }
    }
}
