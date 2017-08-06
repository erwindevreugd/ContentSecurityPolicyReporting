using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ContentSecurityPolicyReporting
{
    public class CSPReportingMiddleware
    {


        private readonly string _endPoint;
        private readonly RequestDelegate _next;
        private readonly ICSPReportReceivedHandler _store;
        private readonly ILogger<CSPReportingMiddleware> _logger;

        public CSPReportingMiddleware(string endPoint, RequestDelegate next, ICSPReportReceivedHandler store, ILoggerFactory logger)
        {
            _endPoint = endPoint;
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _store = store ?? throw new ArgumentNullException(nameof(store));
            _logger = logger?.CreateLogger<CSPReportingMiddleware>() ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Invoke(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context)); // No HttpContext
            if (context.Request == null) { return _next(context); } // No HttpRequest
            if (string.IsNullOrWhiteSpace(_endPoint)) { return _next(context); } // No mapped endpoint

            if (context.Request.IsPost() && context.Request.IsMappedEndpoint(_endPoint))
            {
                var sw = new Stopwatch();
                sw.Start();

                try
                {
                    _logger.LogInformation($"Request starting");

                    var body = context.Request.ReadRequestBody();
                    var report = CSPReportModel.Parse(body);

                    if (report != null)
                    {
                        _logger.LogInformation($"Received Content Security Policy Report {report.ToString()}");

                        _store?.Handle(report);

                        context.SetResponseStatusCode(StatusCodes.Status200OK);
                    }

                    return Task.FromResult(context);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sw.Stop();
                    _logger.LogInformation($"Request finished in {sw.ElapsedMilliseconds}ms");
                }
            }
            else
            {
                return _next(context);
            }            
        }
    }
}
