using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.ViewModels;
using ProgrammingClass4.MvcLesson.Data.Migrations;

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
                .Include(product => product.ProductType)
                .Include(product => product.Measure)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productViewModel = new ProductViewModel
            {
                Manufacturers = _dbContext.Manufacturers.ToList(),
                ProductTypes = _dbContext.ProductTypes.ToList(),
                UnitOfMeasures = _dbContext.UnitOfMeasures.ToList(),
            };
            
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Products.Add(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.Manufacturers = _dbContext.Manufacturers.ToList();
            
            productViewModel.ProductTypes =_dbContext.ProductTypes.ToList();

            productViewModel.UnitOfMeasures =_dbContext.UnitOfMeasures.ToList();

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
                    ProductTypes = _dbContext.ProductTypes.ToList(),
                    Manufacturers = _dbContext.Manufacturers.ToList(),
                    UnitOfMeasures = _dbContext.UnitOfMeasures.ToList(),
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

            productViewModel.ProductTypes = _dbContext.ProductTypes.ToList();

            productViewModel.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(productViewModel);
        }
    }
}
