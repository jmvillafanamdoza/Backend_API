using Proyecto_Integrador_Prestamos.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Repositories;
using System;
using Proyecto_Integrador_Prestamos.Context;
using Microsoft.Data.SqlClient;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly AppDBContext dbContext;

        public PrestamoRepository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Prestamo> CreatePrestamo(Prestamo prestamo)
        {
            if (prestamo == null) throw new ArgumentNullException(nameof(prestamo));
            Console.WriteLine($"Monto: {prestamo.Monto}, Fecha Inicio: {prestamo.fechaIniVigencia}, Fecha Fin: {prestamo.fechaFinVigencia}, Días: {prestamo.diasDuracion}, Pago Diario: {prestamo.pagoDiario}, ID Prestatario: {prestamo.IdPrestatario}");

            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC PRPRESTAMO_INS_PRESTAMO @i_Monto, @i_fechaIniVigencia, @i_fechaFinVigencia, @i_diasDuracion, @i_pagoDiario, @i_IdPrestatario";
                command.Parameters.Add(new SqlParameter("@i_Monto", prestamo.Monto));
                command.Parameters.Add(new SqlParameter("@i_fechaIniVigencia", prestamo.fechaIniVigencia));
                command.Parameters.Add(new SqlParameter("@i_fechaFinVigencia", prestamo.fechaFinVigencia));
                command.Parameters.Add(new SqlParameter("@i_diasDuracion", prestamo.diasDuracion));
                command.Parameters.Add(new SqlParameter("@i_pagoDiario", prestamo.pagoDiario));
                command.Parameters.Add(new SqlParameter("@i_IdPrestatario", prestamo.IdPrestatario));

                await dbContext.Database.OpenConnectionAsync();
                var result = await command.ExecuteScalarAsync();
                dbContext.Database.CloseConnection();

                if (result != null && result != DBNull.Value)
                {
                    prestamo.NroPrestamo = Convert.ToInt32(result);
                }
                return prestamo;
            }
        }

        public async Task<bool> DeletePrestamo(int nroPrestamo)
        {
            var prestamos = await dbContext.Prestamos.FirstOrDefaultAsync(p => p.NroPrestamo == nroPrestamo);
            if (prestamos == null)
            {
                return false;
            }
            dbContext.Prestamos.Remove(prestamos);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamo()
        {
            return await dbContext.Prestamos.ToListAsync();
        }

        public async Task<Prestamo> UpdatePrestamo(Prestamo prestamo)
        {
            dbContext.Prestamos.Update(prestamo);
            await dbContext.SaveChangesAsync();
            return prestamo;
        }
    }
}