using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Models;


namespace Template_Desafio_Ods_Comunidades.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Indicador> Indicadores { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indicador>(entity =>
            {
                // Configurar chave primária composta
                entity.HasKey(e => new { e.IdCodigoArquivo, e.IdCodigoValor });
    
                // Configurar relacionamento com a entidade Responsavel
                entity.HasOne(e => e.Responsavel)
                    .WithMany()
                    .HasForeignKey(e => e.Email)
                    .OnDelete(DeleteBehavior.SetNull); // Ou .OnDelete(DeleteBehavior.ClientSetNull) para comportamento no cliente
    
                // Configurar relacionamento com a entidade Secretaria
                entity.HasOne(e => e.Secretaria)
                    .WithMany()
                    .HasForeignKey(e => e.SiglaSecretaria)
                    .OnDelete(DeleteBehavior.SetNull); // Ou .OnDelete(DeleteBehavior.ClientSetNull) para comportamento no cliente
            });
        }
    }


}
