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
            // Verifica√ß√£o de duplicidade por celular ou email
            var existingResponsavel = await _context.Responsavel
                .FirstOrDefaultAsync(r => r.Celular == responsavel.Celular || r.Email == responsavel.Email);

            if (existingResponsavel != null)
            {
                throw new ArgumentException("J√° existe um respons√°vel com este celular ou email.");
            }

            await _context.Responsavel.AddAsync(responsavel);
            await _context.SaveChangesAsync();

            return responsavel;
        }

<<<<<<< HEAD
        public async Task<Responsavel> DesativarResponsavel(string email, Boolean Ativo)
        {
            var responsavelExistente = await _context.Responsavel
                .FirstOrDefaultAsync(r => r.Email == email);

            if (responsavelExistente == null)
            {
                throw new ArgumentException("Respons√°vel n√£o encontrado.");
            }

            responsavelExistente.Ativo = Ativo; // Invers√£o do status Ativo
=======
        public async Task<Responsavel> AtualizarResponsavel (Responsavel responsavelAtualizado,String email)
        {
            var responsavelExistente = await _context.Responsavel.FirstOrDefaultAsync(r => r.Email == email);
            if (responsavelExistente == null)
            {
                return null; // Ou lanÁar uma exceÁ„o apropriada
            }

            // Atualize os campos do respons·vel existente com os valores do respons·vel atualizado
            responsavelExistente.Nome = responsavelAtualizado.Nome;
            //responsavelExistente.Email = responsavelAtualizado.Email;
            responsavelExistente.Celular = responsavelAtualizado.Celular;
           responsavelExistente.SiglaSecretaria = responsavelAtualizado.SiglaSecretaria;
            // Atualize outros campos conforme necess·rio
>>>>>>> 0dc8ffcbb4653e197c1b30c1bab549d17695c087

            _context.Responsavel.Update(responsavelExistente);
            await _context.SaveChangesAsync();

            return responsavelExistente;
        }
<<<<<<< HEAD
=======

>>>>>>> 0dc8ffcbb4653e197c1b30c1bab549d17695c087
    }
}
