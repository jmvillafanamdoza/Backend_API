
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
        public async Task<JefePrestamista> CreateJefePrestamista(JefePrestamista jefePrestamista)
        {
            _context.JefesPrestamistas.Add(jefePrestamista);
            await _context.SaveChangesAsync();
            return jefePrestamista;
        }

        public async Task<bool> DeleteJefePrestamista(int idJefePrestamista)
        {
            var jefePrestamista = await _context.JefesPrestamistas.FirstOrDefaultAsync(p => p.idJefePrestamista == idJefePrestamista);
            if (jefePrestamista == null)
            {
                return false;
            }
            _context.JefesPrestamistas.Remove(jefePrestamista);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<JefePrestamista>> GetJefePrestamista()
        {
            return await _context.JefesPrestamistas.ToListAsync();
        }

        public async Task<JefePrestamista> UpdateJefePrestamista(JefePrestamista jefePrestamista)
        {
            _context.JefesPrestamistas.Update(jefePrestamista);
            await _context.SaveChangesAsync();
            return jefePrestamista;
        }

        public async Task<IEnumerable<JefePrestamista>> GetJefePrestamistaByCreatorUser(string creatorUser)
        {
            return await _context.JefesPrestamistas.Include(j => j.User).Where(p => p.User.creatorUser == creatorUser).ToListAsync();

        }
    }
}
