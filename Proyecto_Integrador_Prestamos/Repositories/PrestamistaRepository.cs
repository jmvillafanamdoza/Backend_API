using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class PrestamistaRepository :IPrestamistaRepository
    {
        private readonly AppDBContext _context;

        public PrestamistaRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<int?> GetPrestamistaIdByUserIdAsync(int userId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC [dbo].[PRPRESTAMO_OBT_Prestamistas_xidUser_register] @i_idUser_register";
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

        public async Task<Prestamista> CreatePrestamista(Prestamista prestamista)
        {
            _context.Prestamistas.Add(prestamista);
            await _context.SaveChangesAsync();
            return prestamista;
        }

        public async Task<bool> DeletePrestamista(int idPrestamista)
        {
            var prestamista = await _context.Prestamistas.FirstOrDefaultAsync(p => p.idPrestamista == idPrestamista);
            if (prestamista == null)
            {
                return false;
            }
            _context.Prestamistas.Remove(prestamista);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Prestamista>> GetPrestamista()
        {
            return await _context.Prestamistas.ToListAsync();
        }

        public async Task<Prestamista> UpdatePrestamista(Prestamista prestamistas)
        {
            _context.Prestamistas.Update(prestamistas);
            await _context.SaveChangesAsync();
            return prestamistas;
        }

        public async Task<IEnumerable<Prestamista>> GetPrestamistaByCreatorUser(string creatorUser)
        {
            return await _context.Prestamistas.Include(j => j.User).Where(p => p.User.creatorUser == creatorUser).ToListAsync();
        }
    }
}
