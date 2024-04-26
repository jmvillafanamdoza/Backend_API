using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class JefePrestamista  
    {
        [Key]
        public int idJefePrestamista { get; set; }
        // ... otras propiedades ...
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sede { get; set; }
        public string Role { get; set; }




        // Foreign Key para el Inversionista que lo creó
        public int InversionistaId { get; set; }
        [ForeignKey("InversionistaId")]
        public Inversionista Inversionista { get; set; }

        // Relación uno a muchos con Prestamista
        public virtual ICollection<Prestamista> Prestamistas { get; set; }
    }
}
