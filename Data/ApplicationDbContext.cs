using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Models;

namespace Template_Desafio_Ods_Comunidades.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Indicador> Indicador { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Secretaria> Secretaria { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indicador>(entity =>
            {
                // Definir chave primária composta
                entity.HasKey(e => new { e.IdCodigoArquivo, e.IdCodigoValor, e.IdIndicador });

               
                // Definir chave estrangeira para SiglaSecretaria (Secretaria)
                entity.HasOne<Secretaria>()
                    .WithMany()
                    .HasForeignKey(e => e.SiglaSecretaria)
                    .OnDelete(DeleteBehavior.SetNull); // ou DeleteBehavior.ClientSetNull
            });
        }
    }
}
