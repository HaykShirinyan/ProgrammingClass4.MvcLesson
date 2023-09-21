using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class UnitOfMeasures//chapman miavor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
    }
}
