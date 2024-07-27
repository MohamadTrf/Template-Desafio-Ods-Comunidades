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

        public async Task<IEnumerable<Responsavel>> GetAllResponsaveis()
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

        public async Task<Responsavel> DesativarResponsavel(string email, Boolean Ativo)
        {
            var responsavelExistente = await _context.Responsavel
                .FirstOrDefaultAsync(r => r.Email == email);

            if (responsavelExistente == null)
            {
                throw new ArgumentException("Responsável não encontrado.");
            }

            responsavelExistente.Ativo = Ativo; // Inversão do status Ativo

            _context.Responsavel.Update(responsavelExistente);
            await _context.SaveChangesAsync();

            return responsavelExistente;
        }
    }
}
