using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductColorViewModel
    {
        [Required]
        public Product Product { get; set; }
        public List<Color>? Colors { get; set;}
        public List<ProductColor>? ProductColors { get; set;}
        public ProductColor ProductColor { get; set; }

    }
   
}
