namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IUserRepository
    {
        Task<int?> GetUserIdByUserIdAsync(int userId);
    }
}
