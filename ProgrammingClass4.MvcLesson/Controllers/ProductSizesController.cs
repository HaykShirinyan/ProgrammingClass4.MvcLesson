using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

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
           
            ViewBag.Product = _dbContext.Products.Find(productId);
            ViewBag.Sizes   = _dbContext.Sizes.ToList();
           
            return View(productSizes);
        }

        [HttpPost]
        public IActionResult Create(ProductSize productSize)
        {
            _dbContext.ProductSizes.Add(productSize);
            _dbContext.SaveChanges();
            return RedirectToAction("Index",  new {productId = productSize.ProductId});
        }
    }
}
