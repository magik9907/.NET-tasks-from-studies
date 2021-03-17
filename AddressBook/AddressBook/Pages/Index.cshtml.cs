using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AddressBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Address Address
        {
            get;
            set;
        }
        [BindProperty(SupportsGet = true)]
        public string Name
        {
            get;
            set;
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpContext.Session.SetString("SessionAddress",
            JsonConvert.SerializeObject(Address));
            return RedirectToPage("./Address");

        }
    }
}
