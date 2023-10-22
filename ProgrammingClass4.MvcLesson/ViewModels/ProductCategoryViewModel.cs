using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        public Product Product { get; set;}
        public List<Category>? Categories { get; set;}
        public List<ProductCategory>? ProductCategories {  get; set;}
        public ProductCategory ProductCategory { get; set;}
    }
}
