
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
        public async Task<Inversionista> CreateInversionista(Inversionista inversionista)
        {
            _context.Inversionistas.Add(inversionista);
            await _context.SaveChangesAsync();
            return inversionista;
        }

        public async Task<bool> DeleteInversionista(int idInversionista)
        {
            var inversionista = await _context.Inversionistas.FirstOrDefaultAsync(p => p.idInversionista == idInversionista);
            if (inversionista == null)
            {
                return false;
            }
            _context.Inversionistas.Remove(inversionista);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Inversionista>> GetInversionista()
        {
            return await _context.Inversionistas.ToListAsync();
        }

        public async Task<Inversionista> UpdateInversionista(Inversionista inversionista)
        {
            _context.Inversionistas.Update(inversionista);
            await _context.SaveChangesAsync();
            return inversionista;
        }




    }
}
