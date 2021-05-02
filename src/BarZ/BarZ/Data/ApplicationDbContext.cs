using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BarZ.Data.Models;

namespace BarZ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BarZ.Data.Models.Bar> Bar { get; set; }
        public DbSet<BarZ.Data.Models.Destination> Destination { get; set; }
    }
}
