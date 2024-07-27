using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Models;

namespace Template_Desafio_Ods_Comunidades.Service
{
    public class ResponsavelService
    {
        private readonly ApplicationDbContext _context;

        public ResponsavelService(ApplicationDbContext context)
        {
            _context = context;
        }
//
        public async Task<IEnumerable<Responsavel>> GetAllResponsaveis()
        {
            return await _context.Responsavel.ToListAsync();
        }

        public async Task<Responsavel> CadastrarResponsavel(Responsavel responsavel)
        {
            
            await _context.Responsavel.AddAsync(responsavel);

            await _context.SaveChangesAsync();

            return responsavel;
        }
    }
}
