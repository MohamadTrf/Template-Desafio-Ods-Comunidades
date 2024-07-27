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

        public async Task<Responsavel> AtualizarResponsavel (Responsavel responsavelAtualizado,String email)
        {
            var responsavelExistente = await _context.Responsavel.FirstOrDefaultAsync(r => r.Email == email);
            if (responsavelExistente == null)
            {
                return null; // Ou lançar uma exceção apropriada
            }

            // Atualize os campos do responsável existente com os valores do responsável atualizado
            responsavelExistente.Nome = responsavelAtualizado.Nome;
            //responsavelExistente.Email = responsavelAtualizado.Email;
            responsavelExistente.Celular = responsavelAtualizado.Celular;
           responsavelExistente.SiglaSecretaria = responsavelAtualizado.SiglaSecretaria;
            // Atualize outros campos conforme necessário

            _context.Responsavel.Update(responsavelExistente);
            await _context.SaveChangesAsync();

            return responsavelExistente;
        }

    }
}
