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
    public class DetailsModel : PageModel
    {
        private readonly net_task.Data.FizzBuzzContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(net_task.Data.FizzBuzzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            string UserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            FizzBuzz = await _context.FizzBuzzes.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null && FizzBuzz.UserID != UserId)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
