using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Route("ProductColors")]
    public class ProductColorsController : Controller
    {

        private ApplicationDbContext _dbContext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{productId}")]
        public IActionResult Index(int productId)
        {
            var productColors = _dbContext
                .ProductColors
                .Include(productColor => productColor.Color)
                .Where(productColor => productColor.ProductId == productId)
                .ToList();

            var productColorViewModel = new ProductColorViewModel
            {
                Product = _dbContext.Products.Find(productId),
                Colors = _dbContext.Colors.ToList(),
                ProductColors = productColors,
            };
            
            return View(productColorViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductColor productColor)
        {
            _dbContext.ProductColors.Add(productColor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", new {productId =  productColor.ProductId});
        }
    }
}
