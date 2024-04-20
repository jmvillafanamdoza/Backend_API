using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestamo
    {
        [Key]
        public int NroPrestamo { get; set; }
        public decimal Importe { get; set; }
        public string Sede { get; set; }
        public string Moneda { get; set; }
        public int Cuotas { get; set; }
        public string Estado { get; set; }
        public int IdPrestatario { get; set; }
        public string IdPrestamista { get; set; }
    }
}