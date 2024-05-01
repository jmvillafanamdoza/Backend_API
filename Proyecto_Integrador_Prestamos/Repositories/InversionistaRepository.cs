
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class InversionistaRepository : IInversionistaRepository
    {
        private readonly AppDBContext _context;

        public InversionistaRepository(AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //metodos para llamar desde el UserController
        public async Task<int?> GetInversionistaIdByUserIdAsync(int userId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC [dbo].[PRPRESTAMO_OBT_Inversionistas_xidUser_register] @i_idUser_register";
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
