﻿using Proyecto_Integrador_Prestamos.Models;

namespace Proyecto_Integrador_Prestamos.Repositories
{
    public interface IPrestamoRepository
    {
        public Task<IEnumerable<Prestamo>> GetPrestamo();
        public Task<Prestamo> CreatePrestamo(Prestamo prestamo);
        public Task<Prestamo> UpdatePrestamo(Prestamo prestamo);
        public Task<bool> DeletePrestamo(int nroPrestamo);
    }
}