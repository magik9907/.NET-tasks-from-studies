using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AddressBook.Models;

namespace AddressBook.Pages
{
    public class AddressModel : PageModel
    {
        public AddressBook.Models.Address Address;
        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (SessionAddress != null)
                Address = JsonConvert.DeserializeObject<AddressBook.Models.Address>(SessionAddress);
        }
    }
}
