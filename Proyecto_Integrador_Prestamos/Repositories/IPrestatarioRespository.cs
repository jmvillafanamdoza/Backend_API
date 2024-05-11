using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IPrestatarioRepository
    {
        public Task<IEnumerable<Prestatario>> GetPrestatarioByCreatorUser(string creatorUser);
        public Task<Prestatario> GetPrestatarioById(int prestatarioId);
        Task<int?> GetPrestatarioIdByUserIdAsync(int userId);
        public Task<IEnumerable<Prestatario>> GetPrestatario();
        public Task<Prestatario> CreatePrestatario(Prestatario prestatario);
        public Task<Prestatario> UpdatePrestatario(Prestatario prestatario);
        public Task<bool> DeletePrestatario(int idPrestatario);
    }
}