using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ServisInjection.Models;
using Microsoft.AspNetCore.Hosting;

namespace ServisInjection.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "product.json"); }
        }

        public IEnumerable<Product<string>> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                if(jsonFileReader.EndOfStream == false)
                return JsonSerializer.Deserialize<Product<string>[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return null;
            }
        }

    }
}
