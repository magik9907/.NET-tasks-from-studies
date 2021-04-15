using Microsoft.EntityFrameworkCore;
using ServisInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServisInjection.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Product<int>> Products { get; set; }
    }
}
