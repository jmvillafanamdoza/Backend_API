using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestamo
    {
        [Key]
        public int NroPrestamo { get; set; }
        public decimal Monto { get; set; }
        public decimal pagoDiario { get; set; }
        public int diasDuracion { get; set; }
        public string Sede { get; set; }
        public string Moneda { get; set; }
        public int Cuotas { get; set; }
        public string Estado { get; set; }
        public DateTime fechaIniVigencia { get; set; }
        public DateTime fechaFinVigencia { get; set; }

        public int IdPrestatario { get; set; }
        public string IdPrestamista { get; set; }
    }
}