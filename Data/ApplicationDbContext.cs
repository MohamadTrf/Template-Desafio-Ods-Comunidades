using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Models;


namespace Template_Desafio_Ods_Comunidades.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }

        public DbSet<Oligarquia> Oligarquia {get;set;}
    }


}
