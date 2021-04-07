using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;
        public IList<Person> People { get; set; }
        [BindProperty]
        public AddressBook.Models.Address Address
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

        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            People = _context.Person.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpContext.Session.SetString("SessionAddress",
            JsonConvert.SerializeObject(Address));
            return RedirectToPage("./AddressList");

        }
    }
}
