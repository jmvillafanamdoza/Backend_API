using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestamista  
    {
        [Key]
        public int idPrestamista { get; set; }
        // ... otras propiedades ...
        public int idSede { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public int idUser { get; set; }

        [ForeignKey("idUser")]
        public User User { get; set; }
        [ForeignKey("idSede")]
        public Sede Sede { get; set; }

    }
}
