using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Inversionista  
    {
        [Key]
        public int idInversionista { get; set; }
        // ... otras propiedades ...
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sede { get; set; }
        public string Role { get; set; }





        // Relación uno a muchos con JefePrestamista
        public virtual ICollection<JefePrestamista> JefesPrestamistas { get; set; }
    }
}
