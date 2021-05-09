namespace BarZ.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BarZ.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
