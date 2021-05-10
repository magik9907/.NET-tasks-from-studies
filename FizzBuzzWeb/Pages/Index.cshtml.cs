using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using net_task.Models;
using net_task.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using net_task.Filters;

namespace net_task.Pages
{
    [AddAsyncIPFilterAttribute]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            FizzBuzz.Check();
            if (FizzBuzz.State == -1 || FizzBuzz.State == 4)
                return Page();
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.UserID = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            HttpContext.Session.SetString("FizzBuzz", JsonConvert.SerializeObject(FizzBuzz));
            _context.Add(FizzBuzz);
            _context.SaveChanges();
            return Page();
        }

    }
}
