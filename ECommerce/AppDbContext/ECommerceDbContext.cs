using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.AppDbContext
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
    }
}
