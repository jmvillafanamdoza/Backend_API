using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integrador_Prestamos.Models
{
    public partial class User
    {
        [Key]
        public int idUser { get; set; }
        // ... otras propiedades ...
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sede { get; set; }
        public string Role { get; set; }
        public string Estado { get; set; }

        public string Dni { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Token { get; set; }
        public string PrimarySid { get; set; }  // Agregar este campo Id que recibe desde el front del usuario creador 
    }
}
