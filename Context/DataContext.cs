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

        /*
            Muy bien usar el context ! :D 
            Sabias que se puede acceder a la base de datos para mantener un mismo objeto durante todo el 
            proceso de ejecucion? Podemos armar el contexto con toda la informacion que no se va a acceder nuevamente
            a la base de datos a buscarla, y va a sufrir nuevos cambios. Podemos investigar al respecto
            para tener mas conocimientos! (No hace falta aplicarlo) :D
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=workersApi;User=sa;Password=P@ssword1234;Trusted_Connection=False;Encrypt=false");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<DBProject> Projects { get; set; }
    }
}

