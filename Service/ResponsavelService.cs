using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<List<Responsavel>> GetBySigla(string SiglaSecretaria)
        {
            string input = SiglaSecretaria;
            string result = input.Replace(@"\", "").Replace("(", "");
            return _context.Responsavel.Where(s => s.SiglaSecretaria == result.Trim()).ToList();
        }
        public  async Task<Responsavel> AtualizarResponsavel(string SiglaSecretaria, string email, Responsavel responsavel)
        {
            var existeSiglaResponsavel = await _context.Responsavel.FindAsync(SiglaSecretaria);
            var existeEmailResponsavel = await _context.Responsavel.FindAsync(email);

            if (existeSiglaResponsavel == null)
            {
                return null;
            }
            else
            {
                if (existeEmailResponsavel == null)
                {
                    throw new ArgumentException("Responsável não encontrado.");
                }

                // Atualize os campos do responsável existente com os valores do responsável atualizado
                existeSiglaResponsavel.Nome = responsavel.Nome;
                existeSiglaResponsavel.Celular = responsavel.Celular;
                existeSiglaResponsavel.SiglaSecretaria = responsavel.SiglaSecretaria;
                existeSiglaResponsavel.Active = responsavel.Active;
                // Atualize outros campos conforme necessário
                _context.Responsavel.Update(responsavel);
                await _context.SaveChangesAsync();
                return existeSiglaResponsavel;
            }
        }
    }
}
