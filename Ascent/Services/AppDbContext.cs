using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascent.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascent.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
