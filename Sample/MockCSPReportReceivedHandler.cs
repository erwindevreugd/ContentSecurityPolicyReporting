using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentSecurityPolicyReporting;

namespace Sample
{
    public class MockCSPReportReceivedHandler : ICSPReportReceivedHandler
    {
        public async Task Handle(ICSPReport report)
        {
            await Task.Run(() => {

            });
        }
    }
}
