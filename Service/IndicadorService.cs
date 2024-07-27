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
    }
}
