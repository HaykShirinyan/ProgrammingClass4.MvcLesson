using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public int? TypeID { get; set; }
        public ProductType? Type { get; set; }
    }
}
