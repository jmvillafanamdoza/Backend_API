using Proyecto_Integrador_Prestamos.Context;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class CuotaRepository : ICuotaRepository
    {
        private readonly AppDBContext _context;

        public CuotaRepository(AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
