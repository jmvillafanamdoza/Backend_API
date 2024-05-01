using Proyecto_Integrador_Prestamos.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Repositories;
using Proyecto_Integrador_Prestamos.Context;
using Microsoft.Data.SqlClient;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class PrestatarioRepository : IPrestatarioRepository
    {
        private readonly AppDBContext dbContext;

        public async Task<int?> GetPrestatarioIdByUserIdAsync(int userId)
        {
            var idParam = new SqlParameter("@i_idUser_register", userId);
            var result = await dbContext.Database
                .ExecuteSqlRawAsync("EXEC [dbo].[PRPRESTAMO_OBT_Prestatario_xidUser_register] @i_idUser_register", idParam);

            if (result == 0)
            {
                return null; // Or throw an exception if expected behavior is not to find any result
            }

            return (int?)result;
        }
        public PrestatarioRepository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Prestatario> CreatePrestatario(Prestatario prestatario)
        {
            dbContext.Prestatarios.Add(prestatario);
            await dbContext.SaveChangesAsync();
            return prestatario;
        }

        public async Task<bool> DeletePrestatario(int idPrestatario)
        {
            var prestatario = await dbContext.Prestatarios.FirstOrDefaultAsync(p => p.IdPrestatario == idPrestatario);
            if (prestatario == null)
            {
                return false;
            }
            dbContext.Prestatarios.Remove(prestatario);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Prestatario>> GetPrestatario()
        {
            return await dbContext.Prestatarios.ToListAsync();
        }

        public async Task<Prestatario> UpdatePrestatario(Prestatario prestatario)
        {
            dbContext.Prestatarios.Update(prestatario);
            await dbContext.SaveChangesAsync();
            return prestatario;
        }
    }
}