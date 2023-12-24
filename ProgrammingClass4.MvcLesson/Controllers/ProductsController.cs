using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.ViewModels;

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
            var productViewModel = new ProductViewModel
            {
                Manufacturers = _dbContext.Manufacturers.ToList()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product != null)
            {
                var productViewModel = new ProductViewModel
                {
                    Product = product,
                    Manufacturers = _dbContext.Manufacturers.ToList()
                };

                return View(productViewModel);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(productViewModel.Product);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _dbContext
                .Products
                .Include(product => product.Manufacturer)
                .Single(product => product.Id == id);

            return View(product);
        }
    }
}
