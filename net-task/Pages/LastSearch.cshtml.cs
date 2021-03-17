using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using net_task.Models;
namespace net_task.Pages
{
    public class LastSearchModel : PageModel
    {
        public FizzBuzz FizzBuzz;
        public void OnGet()
        {
            var Session = HttpContext.Session.GetString("FizzBuzz");
            if (Session != null)
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(Session);

        }
    }
}
