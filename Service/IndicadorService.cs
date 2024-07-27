using Microsoft.EntityFrameworkCore;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Models;

namespace Template_Desafio_Ods_Comunidades.Service
{
    public class IndicadorService
    {
        private readonly ApplicationDbContext _context;

        public IndicadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Indicador>> GetAllIndicadores()
        {
            return await _context.Indicador.ToListAsync();
        }
        public List<Indicador> GetBySiglaSecretaria(string sigla)
        {
            string input = sigla;
            string result = input.Replace(@"\", "").Replace("(", "");
            return _context.Indicador.Where(s => s.SiglaSecretaria == result.Trim()).ToList();
        }
        public void Add(Indicador indicador)
        {
            _context.Indicador.Add(indicador);
            _context.SaveChanges();

        }
        public async Task<Indicador> UpdateIndicador(string SiglaSecretaria, Indicador indicador)
        {
            var existingIndicador = await _context.Indicador.FindAsync(SiglaSecretaria);
            if (existingIndicador == null)
            {
                return null;
            }

            existingIndicador.IdCodigoValor = indicador.IdCodigoValor;
            existingIndicador.ValorIndicador = indicador.ValorIndicador;
            existingIndicador.Mediana = indicador.Mediana;
            existingIndicador.DesvioPadrao = indicador.DesvioPadrao;
            existingIndicador.LimiteSuperior = indicador.LimiteSuperior;
            existingIndicador.LimiteInferior = indicador.LimiteInferior;
            existingIndicador.SiglaSecretaria = indicador.SiglaSecretaria;

            await _context.SaveChangesAsync();
            return existingIndicador;
        }
        public async Task<bool> DeleteIndicador(string SiglaSecretaria)
        {
            var indicador = await _context.Indicador.FindAsync(SiglaSecretaria);
            if (indicador == null)
            {
                return false;
            }

            _context.Indicador.Remove(indicador);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
