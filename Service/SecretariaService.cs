using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Models;

namespace Template_Desafio_Ods_Comunidades.Service
{
    public class SecretariaService
    {
        private readonly List<Secretaria> _secretarias = new List<Secretaria>();
        private readonly ApplicationDbContext _context;

        public SecretariaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Secretaria> GetAll()
        {
            return _context.Secretaria;
        }

        public Secretaria GetBySiglaSecretaria(string sigla)
        {
            string input = sigla;
            string result = input.Replace(@"\", "").Replace("(", "");
            return _context.Secretaria.FirstOrDefault(s => s.SiglaSecretaria == result.Trim());
        }

        public void Add(Secretaria secretaria)
        {
            _context.Secretaria.Add(secretaria);
            _context.SaveChanges();

        }

        public async Task<bool> Update(string sigla, Secretaria secretariaAtualizada)
        {
                
            var secretariaExistente = await _context.Secretaria.FirstOrDefaultAsync(s => s.SiglaSecretaria == sigla);

                if (secretariaExistente == null)
                {
                    // A secretaria com a sigla especificada não foi encontrada
                    return false;
                }

                // Atualize os campos relevantes da secretaria existente
                secretariaExistente.NomeSecretaria = secretariaAtualizada.NomeSecretaria;
                secretariaExistente.Active = secretariaAtualizada.Active;

                try
                {
                    await _context.SaveChangesAsync();
                    return true; // Atualização bem-sucedida
                }
                catch (Exception)
                {
                    // Lidar com erros de atualização (por exemplo, validação)
                    return false;
                }
            }
        

        public void Deactivate(string SiglaSecretaria)
        {
            var secretaria = _context.Secretaria.FirstOrDefault(s => s.SiglaSecretaria == SiglaSecretaria);
            if (secretaria != null)
            {
                secretaria.Active = false;
            }
            _context.SaveChanges();
        }
    }

}

