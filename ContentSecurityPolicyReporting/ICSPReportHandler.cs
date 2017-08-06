using System.Threading.Tasks;

namespace ContentSecurityPolicyReporting
{
    public interface ICSPReportReceivedHandler
    {
        Task Handle(ICSPReport report);
    }
}
