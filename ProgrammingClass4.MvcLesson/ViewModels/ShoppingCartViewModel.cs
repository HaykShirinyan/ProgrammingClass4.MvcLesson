using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;


namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public List<Product> Products { get; set; }
        public List<Color>? Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<ProductColor>? productColors { get; set; }
        public List<ProductSize> productSizes { get; set; }
        public ProductColor productColor { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public ProductType ProductType { get; set; }
        public List<ProductType>? ProductTypes { get; set; }
        public CartItem CartItem { get; set; }
        public string? UserId { get; set; }
        public int? ProductId { get; set; }
        public int SelectedColorId { get; set; }
        public int SelectedSizeId { get; set; }
        public ShoppingCartColor ShoppingCartColor { get; set; }
        
        [Required(ErrorMessage = "Please select a color.")]
        public string SelectedColorName { get; set; }
        
        [Required(ErrorMessage = "Please select a size.")]
        public ShoppingCartSize ShoppingCartSize { get; set; }
        public string SelectedSizeName { get; set; }

    }

}

