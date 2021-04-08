using Microsoft.EntityFrameworkCore;
using net_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_task.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<FizzBuzz> FizzBuzzes { get; set; }
    }
}
