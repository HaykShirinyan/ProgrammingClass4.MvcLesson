using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        
        public string? UserId { get; set; }
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}