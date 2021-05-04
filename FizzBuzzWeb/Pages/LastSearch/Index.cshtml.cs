using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using net_task.Data;
using net_task.Models;

namespace net_task.Pages.LastSearch
{
    public class IndexModel : PageModel
    {
        private readonly net_task.Data.FizzBuzzContext _context;

        public IndexModel(net_task.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            FizzBuzz = await _context.FizzBuzzes.OrderByDescending( fb => fb.Date).Take(10).ToListAsync();
        }
    }
}
