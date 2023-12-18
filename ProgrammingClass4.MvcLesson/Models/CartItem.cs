using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int? ColorId { get; set; }
        public Color? Color { get; set; }

        public int? SizeId { get; set; }
        public Size? Size { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
