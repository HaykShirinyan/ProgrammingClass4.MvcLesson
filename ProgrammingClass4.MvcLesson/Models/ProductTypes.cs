﻿
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
    
{
    public class ProductTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


    }
}