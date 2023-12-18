namespace ProgrammingClass4.MvcLesson.Models
{
    public class ShoppingCartSize
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
