using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UAParser;
namespace ServisInjection.Middleware
{
    public class BrowserControllMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserControllMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var site = context.Request.Path;
            string ua = context.Request.Headers["user-agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo cl = uaParser.Parse(ua);
            var browser = cl.UserAgent.Family;
            if (site != "/NotSupported" && (browser.Contains("Edge") || browser.Contains("EedgeChromium") || browser.Contains("IE")))
                context.Response.Redirect("NotSupported");
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
