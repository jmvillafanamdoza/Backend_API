using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Inversionista  
    {
        [Key]
        public int idInversionista { get; set; }
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
