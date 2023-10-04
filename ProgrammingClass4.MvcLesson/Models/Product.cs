﻿using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.MvcLesson.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public int? TypeID { get; set; }//foreign key
        public ProductType? Type { get; set; }//ProductTypei Type propertieya sarqaca vorpesi cragir@ haskana vor verevum TypeID in foreign keya

        public int? UnitOfMeasureId { get; set; }//foreign key
        public UnitOfMeasures? UnitOfMeasure { get; set; }//UnitOfMeasures UnitOfMeasure propertieya sarqac vor cragir@ haskana vor verevum foreign keya sarqac

    }
}
