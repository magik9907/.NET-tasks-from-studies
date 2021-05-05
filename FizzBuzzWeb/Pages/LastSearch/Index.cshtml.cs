using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using net_task.Data;
using net_task.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace net_task.Pages.LastSearch
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string UserId { get; set; }
        private readonly net_task.Data.FizzBuzzContext _context;
        private readonly UserManager<IdentityUser> _userManager;
      
        public IndexModel(net_task.Data.FizzBuzzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<FizzBuzz> FizzBuzz { get; set; }

        public async Task OnGetAsync()
        {
            UserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            FizzBuzz = await _context.FizzBuzzes.OrderByDescending(fb => fb.Date).Take(20).ToListAsync();
        }
    }
}
