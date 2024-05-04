using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IPrestamistaRepository
    {
        public Task<IEnumerable<Prestamista>> GetPrestamistaByCreatorUser(string creatorUser);
        Task<int?> GetPrestamistaIdByUserIdAsync(int userId);
        public Task<IEnumerable<Prestamista>> GetPrestamista();
        public Task<Prestamista> CreatePrestamista(Prestamista prestamista);
        public Task<Prestamista> UpdatePrestamista(Prestamista prestamista);
        public Task<bool> DeletePrestamista(int idPrestamista);
    }
}
