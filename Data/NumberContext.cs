using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace FizzBuzzWeb.Data
{
    public class NumberContext : DbContext
    {
        public NumberContext(DbContextOptions options) : base(options) { }
        public DbSet<Number> Number { get; set; }
    }

}
