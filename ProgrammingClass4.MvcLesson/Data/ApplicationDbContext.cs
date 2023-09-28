using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Controllers;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; } //generic type , darnuma ProductType ov DbSet
        public DbSet<UnitOfMeasures> UnitOfMeasures { get; set; }
        public object UnitOfMeasure { get; internal set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public static implicit operator ApplicationDbContext(ProductTypeController v)
        {
            throw new NotImplementedException();
        }
    }
}