using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModels
{
    public class SellerVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere el nombre")]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Se requiere los apellidos")]
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Se requiere el celular")]
        [DisplayName("Celular")]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }
        [Required(ErrorMessage = "Se requiere la direccion")]
        [DisplayName("Direccion")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Se requiere el estado")]
        [DisplayName("Estado")]
        public string City { get; set; }
        [Required(ErrorMessage = "Se requiere el correo")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Se requiere la contraseña")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha")]
        [DisplayName("Fecha")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}