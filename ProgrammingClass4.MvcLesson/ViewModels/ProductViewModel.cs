using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public Product Product { get; set; }
        public List<ProductType>? ProductTypes { get; set; }
        public List<Manufacturer>? Manufacturers { get; set; }
        public List<UnitOfMeasure>? UnitOfMeasures { get; set; }
        public List<Product>? Products { get; set; }
        public List<Color>? Colors { get; set; }
        public List<Size>? Sizes { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public int SelectedColorId { get; set; }
        public int SelectedSizeId { get; set;}
        public int CartItemId { get; set; }
        public int Quantity { get; set; }


    }

}
