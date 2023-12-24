using Microsoft.AspNetCore.Identity;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class ShoppingCartProduct
    {
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
