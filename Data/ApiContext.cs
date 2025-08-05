using Microsoft.EntityFrameworkCore;
using Ver_Estado_Admision;

namespace Data
{
    public class OracleContext : DbContext
    {
        public OracleContext(DbContextOptions<OracleContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }

}