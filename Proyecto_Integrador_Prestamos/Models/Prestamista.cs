﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class Prestamista  
    {
        [Key]
        public int idPrestamista { get; set; }
        // ... otras propiedades ...
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sede { get; set; }
        public string Role { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public int JefePrestamistaId { get; set; }
        public int idUser_register { get; set; }
        // Foreign Key para el JefePrestamista que lo creó

        //[ForeignKey("JefePrestamistaId")]
        //public JefePrestamista JefePrestamista { get; set; }

        //// Relación uno a muchos con Prestatario
        //public virtual ICollection<Prestatario> Prestatarios { get; set; }

    }
}
