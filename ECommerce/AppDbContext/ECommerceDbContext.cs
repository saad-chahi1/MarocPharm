using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.AppDbContext
{
    public class ECommerceDbContext:IdentityDbContext<AppUser>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
    }
}
