namespace ProgrammingClass4.MvcLesson.Models
{
    public class ProductShoppingCart
    {
        public int ProductId { get; set; } //foreign key
        public Product? Product { get; set; }
        public int ShoppingCartId { get; set;} //foreign key
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
