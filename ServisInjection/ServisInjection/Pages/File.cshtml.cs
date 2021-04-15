using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServisInjection.Models;
using ServisInjection.Services;

namespace ServisInjection.Pages
{
    public class FileModel : PageModel
    {
        public JsonFileProductService JsonService { get; }
        public IEnumerable<Product<string>> Products { get; private set; }
        public FileModel (JsonFileProductService jsonService)
        {
            JsonService = jsonService;
        }
        public void OnGet()
        {
            Products = JsonService.GetProducts();
        }
    }
}
