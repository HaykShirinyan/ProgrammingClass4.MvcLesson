namespace ProgrammingClass4.MvcLesson.Models
{
    public class CartColor
    {
        public int CartItemId { get; set; }
        public CartItem CartItem { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
