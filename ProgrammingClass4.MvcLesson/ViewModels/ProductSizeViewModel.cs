using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductSizeViewModel
    {
        [Required]
        public Product Product { get; set;}
        public List<Size>? Sizes { get; set;}
        public List<ProductSize>? ProductSizes { get; set;}
        public ProductSize ProductSize { get; set;}
    }
}
