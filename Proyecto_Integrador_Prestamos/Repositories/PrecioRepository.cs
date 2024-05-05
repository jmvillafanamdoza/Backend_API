using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class PrecioRepository : IPreciosRepository
    {
        private readonly AppDBContext _context;
        public PrecioRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Precio> CreatePrecio(Precio precio)
        {
            _context.Precios.Add(precio);
            await _context.SaveChangesAsync();
            return precio;
        }

        public async Task<IEnumerable<Precio>> GetPrecio()
        {
            return await _context.Precios.ToListAsync();
        }
    }
}
