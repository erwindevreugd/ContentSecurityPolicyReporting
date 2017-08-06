# Content Security Policy Reporting middleware for ASP.NET Core

The Content Security Policy Reporting middleware for ASP.NET Core adds an api endpoint to an ASP.NET Core application for browsers to report content security policy violations.

How to use Content Security Policy Reporting middleware for ASP.NET Core
--------------------------------

Add a NuGet reference to the **ContentSecurityPolicyReporting** package.

```JSON
"dependencies": {
        "ContentSecurityPolicyReporting": "version"
    }
```

```XML
<ItemGroup>
    <PackageReference Include="ContentSecurityPolicyReporting" Version="version" />
</ItemGroup>
```
Create a handler that implements the **ICSPReportReceivedHander** interface.
The handler will be called everytime a Content Security Policy Report is received on the registered endpoint.

```C#
public class MockCSPReportReceivedHandler : ICSPReportReceivedHandler
{
    public async Task Handle(ICSPReport report)
    {
        await Task.Run(() => {

        });
    }
}
```
Register the handler in the **ConfigureServices** method.
```C#
public void ConfigureServices(IServiceCollection services)
{
    // Add a handler for received content security policy reports
    services.AddCSPReporting(new MockCSPReportReceivedHandler());

    // Add framework services.
    services.AddMvc();
}
```
Map the Content Security Policy Reporting middleware to a endpoint.
```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    // Map content security policy reporting api to an endpoint
    app.UseCSPReporting("Content-Security-Policy-Reporting-Endpoint");

    app.UseStaticFiles();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
}
```