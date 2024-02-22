using System;
using Microsoft.EntityFrameworkCore;
using workersApi.Models;

namespace workersApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=workersApi;User=sa;Password=P@ssword1234;Trusted_Connection=False;Encrypt=false");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<DBProject> Projects { get; set; }
    }
}

