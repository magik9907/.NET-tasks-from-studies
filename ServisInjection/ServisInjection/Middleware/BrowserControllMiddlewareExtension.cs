using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
namespace ServisInjection.Middleware
{
    public static class BrowserControllMiddlewareExtension
    {
        public static IApplicationBuilder UseBrowserValidate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserControllMiddleware>();
        }
    }
}
