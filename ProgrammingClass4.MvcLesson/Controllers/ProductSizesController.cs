using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Route ("ProductSize")]
    public class ProductSizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductSizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet ("{productId}")]
        public IActionResult Index( int productId)
        {
            var productSizes = _dbContext
                .ProductSizes
                .Include(productSize=> productSize.Size)
                .Where(productSize=> productSize.ProductId == productId)
                .ToList();
            
            var productSizeViewModel = new ProductSizeViewModel
            {
                Product = _dbContext.Products.Find(productId),
                Sizes = _dbContext.Sizes.ToList(),
                ProductSizes = productSizes
            };

            return View(productSizeViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductSizeViewModel productSizeViewModel)
        {
           _dbContext.ProductSizes.Add(productSizeViewModel.ProductSize);
           _dbContext.SaveChanges();
            return RedirectToAction("Index", new { productId = productSizeViewModel.ProductSize.ProductId });
        }
  
    }
}
