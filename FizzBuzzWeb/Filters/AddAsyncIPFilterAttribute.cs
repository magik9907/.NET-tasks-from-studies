using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_task.Filters
{
    public class AddAsyncIPFilterAttribute : ResultFilterAttribute
    {

        public AddAsyncIPFilterAttribute ()
        {
        }
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var page = context.Result;
            if (page is PageResult)
            {
                var model = ((PageResult)page);
                model.ViewData["Filter"] =context.HttpContext.Connection.RemoteIpAddress?.ToString();
            }
            return base.OnResultExecutionAsync(context, next);
        }
    }
}
