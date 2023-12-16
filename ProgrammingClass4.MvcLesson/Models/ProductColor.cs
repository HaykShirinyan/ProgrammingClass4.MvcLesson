namespace ProgrammingClass4.MvcLesson.Models
{
    public class ProductColor
    {
        public int ProductId{ get; set; } //foreign key
        public Product? Product { get; set; }
        public int ColorId { get; set; } //foreign key
        public Color? Color { get; set; }

    }
}
