using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CartColor> CartColors { get; set; }
        public DbSet<ShoppingCartColor> ShoppingCartColors { get; set; }
        public DbSet<ShoppingCartSize> ShoppingCartSizes { get; set; }
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCategory>()
                .HasKey(productCategory => new { productCategory.ProductId, productCategory.CategoryId });
            builder.Entity<ProductColor>()
                .HasKey(productColor => new { productColor.ProductId, productColor.ColorId });
            builder.Entity<ProductSize>()
                .HasKey(productSize => new {productSize.ProductId, productSize.SizeId });
            builder.Entity<CartColor>()
                .HasKey(cartColor => new { cartColor.CartItemId, cartColor.ColorId });
            builder.Entity<ShoppingCartColor>()
                .HasKey(shoppingCartColor => new { shoppingCartColor.ShoppingCartId, shoppingCartColor.ColorId });
            builder.Entity<ShoppingCartSize>()
                .HasKey(shoppingCartSize => new {shoppingCartSize.ShoppingCartId, shoppingCartSize.SizeId});
        }
    }
}