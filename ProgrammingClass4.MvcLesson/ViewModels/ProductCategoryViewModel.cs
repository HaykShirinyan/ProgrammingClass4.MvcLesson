using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set;}
        public List<Category>? Categories { get; set;}
        public List<ProductCategory>? ProductCategories {  get; set;}
        public ProductCategory ProductCategory { get; set;}
    }
}
