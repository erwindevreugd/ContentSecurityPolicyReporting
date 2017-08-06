using Microsoft.Extensions.DependencyInjection;

namespace ContentSecurityPolicyReporting
{
    public class CSPReportingBuilder : ICSPReportingBuilder
    {
        public CSPReportingBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
