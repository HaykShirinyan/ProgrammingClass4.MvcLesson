using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(100)]
        public string Description { get; set; }
    }
}
