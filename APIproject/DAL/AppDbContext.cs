using APIproject.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIproject.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }

    }
}
