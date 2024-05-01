using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Sede
    {
        [Key]
        public int idSede { get; set; }
        // ... otras propiedades ...
        public string descripcionSede { get; set; }
        public string Estado { get; set; }

    }
}
