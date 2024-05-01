namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IPrestamistaRepository
    {
        Task<int?> GetPrestamistaIdByUserIdAsync(int userId);
    }
}
