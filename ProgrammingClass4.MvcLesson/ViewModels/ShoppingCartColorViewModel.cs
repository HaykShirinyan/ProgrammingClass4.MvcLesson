using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.ViewModels
{
    public class ShoppingCartColorViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<Color>? Colors { get; set; }
        public List<ShoppingCartColor>? ShoppingCartColors { get; set; }
        public ShoppingCartColor ShoppingCartColor { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public int Id { get; set; }
        public string SelectedColorName { get; set; }
    }
}
