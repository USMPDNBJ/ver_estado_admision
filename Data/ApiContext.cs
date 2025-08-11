using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<PreInscripcion> Preinscripcion { get; set; }
        public DbSet<Postulante> Postulantes { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Vacante> Vacantes { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PreInscripcion>()
    .ToTable("MA_PREINSCRIPCION", schema: "OAUSMP");
            modelBuilder.Entity<Sede>()
            .ToTable("TA_SEDE", schema: "OAUSMP");
            modelBuilder.Entity<Postulante>()
.ToTable("MA_POSTULANTE", schema: "OAUSMP");
            modelBuilder.Entity<PreInscripcion>()
            .HasOne(p => p.Postulante)
            .WithOne(p => p.PreInscripcion)
            .HasForeignKey<Postulante>(p => p.Id);
        }

        public async Task VerificarConexionAsync()
        {
            try
            {
                // Intentar una operación simple como una consulta
                await this.Database.OpenConnectionAsync();
                await this.Database.CloseConnectionAsync();
                Console.WriteLine("Conexión exitosa a la base de datos Oracle.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }
    }

}