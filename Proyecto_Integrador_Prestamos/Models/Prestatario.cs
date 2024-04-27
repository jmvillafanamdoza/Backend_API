using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestatario
    {
        [Key]
        public int IdPrestatario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Role { get; set; }

        public int PrestamistaId { get; set; }
        // Foreign Key para el Prestamista que lo creó
        //
        //[ForeignKey("PrestamistaId")]
        //public Prestamista Prestamista { get; set; }
    }
}