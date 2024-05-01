
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;


namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class JefePrestamistaRepository : IJefePrestamistaRepository
    {
        private readonly AppDBContext _context;

        public JefePrestamistaRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<int?> GetJefePrestamistaIdByUserIdAsync(int userId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC [dbo].[PRPRESTAMO_OBT_JefesPrestamistas_xidUser_register] @i_idUser_register";
                command.Parameters.Add(new SqlParameter("@i_idUser_register", userId));

                _context.Database.OpenConnection();
                var result = await command.ExecuteScalarAsync();
                _context.Database.CloseConnection();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                return null;
            }
        }
    
    }
}
