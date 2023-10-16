using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Data.Migrations;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Route("ProductCategories")]
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{productId}")]
        public IActionResult Index(int productId)
        {
            var productCategories = _dbContext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == productId)
                .ToList();
            
            var productCategoryViewModel = new ProductCategoryViewModel
            {

                ProductCategories = productCategories,
                Product = _dbContext.Products.Find(productId),
                Categories = _dbContext.Categories.ToList(),
                
            };
            return View(productCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory) 
        {
            _dbContext.ProductCategories.Add(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }
    }
}
