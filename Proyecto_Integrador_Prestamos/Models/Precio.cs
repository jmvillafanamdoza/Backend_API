using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Integrador_Prestamos.Models
{
    public class Precio
    {
        [Key]
        public int Id { get; set; }
        public string DuracionDias { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio150 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio200 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio300 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio400 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio500 { get; set; }
    }
}
