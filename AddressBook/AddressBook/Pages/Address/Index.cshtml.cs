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
    public class IndexModel : PageModel
    {
        private readonly AddressBook.Data.PeopleContext _context;

        public IndexModel(AddressBook.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<AddressDB> AddressDB { get;set; }

        public async Task OnGetAsync()
        {
            AddressDB = await _context.Address.ToListAsync();
        }
    }
}
