using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IInversionistaRepository
    {
        // metodo para llamar desde el user controller

        Task<int?> GetInversionistaIdByUserIdAsync(int userId);
        public Task<IEnumerable<Inversionista>> GetInversionista();
        public Task<Inversionista> CreateInversionista(Inversionista inversionista);
        public Task<Inversionista> UpdateInversionista(Inversionista inversionista);
        public Task<bool> DeleteInversionista(int idInversionista);

    }
}
