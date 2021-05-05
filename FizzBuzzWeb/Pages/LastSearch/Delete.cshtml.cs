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
    public class DeleteModel : PageModel
    {
        private readonly net_task.Data.FizzBuzzContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(net_task.Data.FizzBuzzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        string UserId;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }
          
            UserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            FizzBuzz = GetFromDB(id);
           
            if (FizzBuzz != null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            UserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            FizzBuzz = GetFromDB(id);

            if (FizzBuzz != null)
            {
                _context.FizzBuzzes.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        private FizzBuzz GetFromDB(int? id)
        {
            return (from r in _context.FizzBuzzes
                    where r.Id.Equals(id)
                    && r.UserID.Equals(UserId)
                    select r).FirstOrDefault();
        }
    }
}
