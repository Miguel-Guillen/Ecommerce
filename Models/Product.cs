using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public double Cost { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public string ShippingType { get; set; }
        public DateTime Date { get; set; }
        public string Img { get; set; }
        public Seller? Seller { get; set; }
    }
}