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
    public class DeleteModel : PageModel
    {
        private readonly AddressBook.Data.PeopleContext _context;

        public DeleteModel(AddressBook.Data.PeopleContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressDB = await _context.Address.FindAsync(id);

            if (AddressDB != null)
            {
                _context.Address.Remove(AddressDB);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
