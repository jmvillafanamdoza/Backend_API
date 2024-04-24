﻿using Proyecto_Integrador_Prestamos.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_Integrador_Prestamos.Repositories;
using System;
using Proyecto_Integrador_Prestamos.Context;

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
            dbContext.Prestamos.Add(prestamo);
            await dbContext.SaveChangesAsync();
            return prestamo;
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