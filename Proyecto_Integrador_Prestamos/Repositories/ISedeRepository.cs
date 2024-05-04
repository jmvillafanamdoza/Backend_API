using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface ISedeRepository
    {
        public Task<Sede> GetSedeById(int idSede);
        public Task<IEnumerable<Sede>> GetSede();
        public Task<Sede> CreateSede(Sede sede);
        public Task<Sede> UpdateSede(Sede sede);
        public Task<bool> DeleteSede(int idSede);
    }
}
