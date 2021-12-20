using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgricultureManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tractor> Tractors { get; set; }

        public DbSet<Combine> Combines { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<Header> Header { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<AgricultureManagementSystem.Models.Activity> Activity { get; set; }
    }
}
