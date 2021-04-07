using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.Pages.Address
{
    public class CreateModel : PageModel
    {
        private readonly AddressBook.Data.PeopleContext _context;

        public CreateModel(AddressBook.Data.PeopleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddressDB AddressDB { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Address.Add(AddressDB);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
