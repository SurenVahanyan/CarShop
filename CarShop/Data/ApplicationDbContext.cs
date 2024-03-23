using CarShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbContextOptions<ApplicationDbContext> Options { get; set; }

        public DbSet<Car> Categories { get; set; }
        public object Cars { get; internal set; }
    }
}
