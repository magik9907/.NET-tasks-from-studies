using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServisInjection.Data;
using ServisInjection.Models;
namespace ServisInjection.Pages
{
    public class DatabaseModel : PageModel
    {
        public ProductContext context { get; set; }
        public IEnumerable<Product<int>> Products { get; private set; }
        public DatabaseModel(ProductContext pc)
        {
            context = pc;
        }

        public void OnGet()
        {
            Products = context.Products;
        }
    }
}
