using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestamo
    {
        [Key]
        public int NroPrestamo { get; set; }
        public decimal Monto { get; set; }
        public decimal pagoDiario { get; set; }
        public int diasDuracion { get; set; }
        public string Estado { get; set; }
        public DateTime fechaIniVigencia { get; set; }
        public DateTime fechaFinVigencia { get; set; }
        public int idPrestatario { get; set; }
        public int idPrestamista { get; set; }

    }
}