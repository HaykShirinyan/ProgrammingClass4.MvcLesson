using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public Product? Product { get; set; }
        public List<ProductType>? ProductTypes { get; set; }
        public int CartCount { get; set; }

    }
}
 