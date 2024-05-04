using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IJefePrestamistaRepository
    {
        public Task<IEnumerable<JefePrestamista>> GetJefePrestamistaByCreatorUser(string creatorUser);
        Task<int?> GetJefePrestamistaIdByUserIdAsync(int userId);
        public Task<IEnumerable<JefePrestamista>> GetJefePrestamista();
        public Task<JefePrestamista> CreateJefePrestamista(JefePrestamista jefePrestamista);
        public Task<JefePrestamista> UpdateJefePrestamista(JefePrestamista jefePrestamista);
        public Task<bool> DeleteJefePrestamista(int idJefePrestamista);
    }
}
