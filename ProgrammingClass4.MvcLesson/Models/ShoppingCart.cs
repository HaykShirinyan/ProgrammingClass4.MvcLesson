using Microsoft.AspNetCore.Identity;
using ProgrammingClass4.MvcLesson.Data;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
        public string? UserId {  get; set; }
        public IdentityUser? User { get; set; }
    }
}
