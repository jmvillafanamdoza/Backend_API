using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IUserRepository
    {
        Task<int?> GetUserIdByUserIdAsync(int userId);
        public Task<User> GetUserById(int userId);
    }
}
