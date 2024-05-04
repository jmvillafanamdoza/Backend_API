using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Context;
using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class SedeRepository : ISedeRepository
    {
        private readonly AppDBContext dbContext;

        public SedeRepository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Sede> GetSedeById(int idSede)
        {
            var sede = await dbContext.Sedes.Where(p => p.idSede == idSede).FirstOrDefaultAsync();

            if (sede == null)
            {
                return null;
            }
            return sede;
        }
        public async Task<Sede> CreateSede(Sede sede)
        {
            dbContext.Sedes.Add(sede);
            await dbContext.SaveChangesAsync();
            return sede;
        }

        public async Task<bool> DeleteSede(int idSede)
        {
            var sede = await dbContext.Sedes.FirstOrDefaultAsync(p => p.idSede == idSede);
            if (sede == null)
            {
                return false;
            }
            dbContext.Sedes.Remove(sede);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Sede>> GetSede()
        {
            return await dbContext.Sedes.ToListAsync();
        }

        public async Task<Sede> UpdateSede(Sede sede)
        {
            dbContext.Sedes.Update(sede);
            await dbContext.SaveChangesAsync();
            return sede;
        }
    }
}
