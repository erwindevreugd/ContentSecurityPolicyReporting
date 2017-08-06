using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContentSecurityPolicyReporting
{
    internal static class HttpContextExtensions
    {
        public static void SetResponseStatusCode(this HttpContext context, int statusCode)
        {
            context.Response.StatusCode = statusCode;
        }
    }
}
