using Template_Desafio_Ods_Comunidades.Data;

namespace Template_Desafio_Ods_Comunidades.Service
{
    public class OligarquiaService
    {
        private readonly ApplicationDbContext _context;

        public OligarquiaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<String> ServiceTesteOligarquia()
        {
            return  "teste";
        }
    }
}
