using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _dbContext
                .Products
                .Include(product => product.Manufacturer)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product != null)
            {
                ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }
    }
}
