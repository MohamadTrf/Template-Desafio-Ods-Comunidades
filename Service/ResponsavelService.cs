using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template_Desafio_Ods_Comunidades.Service
{
    public class ResponsavelService
    {
        private readonly ApplicationDbContext _context;

        public ResponsavelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Responsavel>> GetAll()
        {
            return await _context.Responsavel.ToListAsync();
        }

        public async Task<Responsavel> CadastrarResponsavel(Responsavel responsavel)
        {
            // Verificação de duplicidade por celular ou email
            var existingResponsavel = await _context.Responsavel
                .FirstOrDefaultAsync(r => r.Celular == responsavel.Celular || r.Email == responsavel.Email);

            if (existingResponsavel != null)
            {
                throw new ArgumentException("Já existe um responsável com este celular ou email.");
            }

            await _context.Responsavel.AddAsync(responsavel);
            await _context.SaveChangesAsync();

            return responsavel;
        }

        public async Task<Responsavel> DesativarResponsavel(string email, bool Active)
        {
            var responsavelExistente = await _context.Responsavel
                .FirstOrDefaultAsync(r => r.Email == email);

            if (responsavelExistente == null)
            {
                throw new ArgumentException("Responsável não encontrado.");
            }

            responsavelExistente.Active = Active; // Atualiza o status Ativo

            _context.Responsavel.Update(responsavelExistente);
            await _context.SaveChangesAsync();

            return responsavelExistente;
        }

        public async Task<List<Responsavel>> GetResponsavelBySecretaria(string siglaSecretaria)
        {
            if (string.IsNullOrWhiteSpace(siglaSecretaria))
            {
                throw new ArgumentException("Sigla da secretaria não pode ser nula ou vazia", nameof(siglaSecretaria));
            }

            var responsaveis = await _context.Responsavel
                .Where(r => r.SiglaSecretaria == siglaSecretaria)
                .ToListAsync();

            if (responsaveis == null || responsaveis.Count == 0)
            {
                // Handle the case when no responsaveis are found
                throw new KeyNotFoundException($"Nenhum responsável encontrado para a secretaria: {siglaSecretaria}");
            }

            return responsaveis;
        }

        public async Task<Responsavel> AtualizarResponsavel(Responsavel responsavelAtualizado, string email)
        {
            var responsavelExistente = await _context.Responsavel.FirstOrDefaultAsync(r => r.Email == email);
            if (responsavelExistente == null)
            {
                throw new ArgumentException("Responsável não encontrado.");
            }

            // Atualize os campos do responsável existente com os valores do responsável atualizado
            responsavelExistente.Nome = responsavelAtualizado.Nome;
            responsavelExistente.Celular = responsavelAtualizado.Celular;
            responsavelExistente.SiglaSecretaria = responsavelAtualizado.SiglaSecretaria;
            // Atualize outros campos conforme necessário

            _context.Responsavel.Update(responsavelExistente);
            await _context.SaveChangesAsync();

            return responsavelExistente;
        }
    }
}
