namespace ProgrammingClass4.MvcLesson.Models
{
    public class ShoppingCartColor
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
   
    }
}
