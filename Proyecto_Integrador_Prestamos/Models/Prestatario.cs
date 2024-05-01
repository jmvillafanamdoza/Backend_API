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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sede { get; set; }
        public string Role { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public int idUser_register { get; set; }
        public int PrestamistaId { get; set; }




    }
}