using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModels
{
    public class ProductVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere el vendedor")]
        [DisplayName("Vendedor")]
        public int SellerId { get; set; }
        [Required(ErrorMessage = "Se requiere el id del vendedor")]
        [DisplayName("Vendedor")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Se requiere la descripcion")]
        [DisplayName("Descripcion")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Se requiere la categoria")]
        [DisplayName("Categoria")]
        public int Category { get; set; }
        [Required(ErrorMessage = "El minimo debe ser 1")]
        [DisplayName("Costo")]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        [Required(ErrorMessage = "El minimo debe ser 0")]
        [DisplayName("Descuento")]
        [DataType(DataType.Currency)]
        public int Discount { get; set; }
        [Required(ErrorMessage = "El minimo debe ser 0")]
        [DisplayName("Stock")]
        [DataType(DataType.Currency)]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Se requiere el tipo de envio")]
        [DisplayName("Tipo de envio")]
        public string ShippingType { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha")]
        [DisplayName("Fecha")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Se requiere una imagen")]
        [DisplayName("Imagen")]
        [DataType(DataType.ImageUrl)]
        public string Img { get; set; }
    }
}