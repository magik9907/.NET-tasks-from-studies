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

namespace net_task.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public IndexModel(ILogger<IndexModel> logger,FizzBuzzContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            FizzBuzz.Check();
            if (FizzBuzz.State == -1 || FizzBuzz.State == 4)
                return Page();
            FizzBuzz.Date = DateTime.Now;
            HttpContext.Session.SetString("FizzBuzz", JsonConvert.SerializeObject(FizzBuzz));
            _context.Add(FizzBuzz);
            _context.SaveChanges();
            return Page();
        }
    }
}
