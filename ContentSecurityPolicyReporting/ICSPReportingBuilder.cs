using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContentSecurityPolicyReporting
{
    public interface ICSPReportingBuilder
    {
        IServiceCollection Services { get; }
    }
}
