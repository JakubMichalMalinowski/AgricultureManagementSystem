using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        public DbSet<AgricultureManagementSystem.Models.Header> Header { get; set; }
    }
}
