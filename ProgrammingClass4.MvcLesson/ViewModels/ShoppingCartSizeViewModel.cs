using ProgrammingClass4.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ShoppingCartSizeViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<ShoppingCartSize>? ShoppingCartSizes { get; set; }
        public ShoppingCartSize ShoppingCartSize { get; set; }
        public Product Product { get; set; }
        public int SizeId { get; set; }
        public int Id { get; set; }
        public string SelectedSizeName { get; set; }
    }
}
