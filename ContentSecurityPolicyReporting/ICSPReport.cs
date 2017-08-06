namespace ContentSecurityPolicyReporting
{
    public interface ICSPReport
    {
        string DocumentUri { get; set; }
        string Refferer { get; set; }
        string BlockedUri { get; set; }
        string ViolatedDirective { get; set; }
        string OriginalPolicy { get; set; }
        string Disposition { get; set; }
    }
}
