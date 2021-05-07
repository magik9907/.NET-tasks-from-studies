using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_task.Filters
{
    public class AddAsyncIPFilter : IAsyncPageFilter
    {
        private readonly IConfiguration _config;
        public AddAsyncIPFilter(IConfiguration config)
        {
            _config = config;
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;

        }
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                PageHandlerExecutionDelegate next)
        {
            // Do post work.
            await next.Invoke();
        }

    }
}
