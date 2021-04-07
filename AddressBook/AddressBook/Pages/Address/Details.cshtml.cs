using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly AddressBook.Data.PeopleContext _context;

        public DetailsModel(AddressBook.Data.PeopleContext context)
        {
            _context = context;
        }

        public AddressDB AddressDB { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressDB = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);

            if (AddressDB == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
