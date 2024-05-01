namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IInversionistaRepository
    {
        // metodo para llamar desde el user controller

        Task<int?> GetInversionistaIdByUserIdAsync(int userId);

   
    }
}
