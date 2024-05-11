using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Cuota
    {
        [Key]
        public int NroCorrelativo { get; set; }
        public int NroPrestamo { get; set; }
        public int NroCuota { get; set; }
        public decimal pagoDiario { get; set; }
        public string Estado { get; set; }
        public int IdPrestatario { get; set; }
        public DateTime FechaCuota { get; set; }
        


    }
}
