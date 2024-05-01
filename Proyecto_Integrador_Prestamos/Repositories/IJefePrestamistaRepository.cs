namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IJefePrestamistaRepository
    {
        Task<int?> GetJefePrestamistaIdByUserIdAsync(int userId);
    }
}
