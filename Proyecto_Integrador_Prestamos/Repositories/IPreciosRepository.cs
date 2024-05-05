using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IPreciosRepository
    {
        public Task<IEnumerable<Precio>> GetPrecio();
        public Task<Precio> CreatePrecio(Precio precio);
    }
}
