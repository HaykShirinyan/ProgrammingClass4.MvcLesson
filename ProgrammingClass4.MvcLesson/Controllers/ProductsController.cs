using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //Include(product=>product.Type) iranic nerkayacnum e lyambda tesaki funkcia,et funkcian ira mej arden uni Product class@,
            List<Product> products = _dbContext
                .Products
                .Include(product => product.Manufacturer)
                .Include(product => product.Type)
                .Include(product => product.UnitOfMeasure)
                .ToList();
            
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // sarqum enq ViewBag,u nra ProductTypei mej texadrum enq ProductTyperi List@,vorpeszi dropdown sarqenq
            // ViewBagi mijocov enq anum vorovhetev mer @model@ Productsa,voch te ProdutsList,es depqum @model@ chi karox ham products linel ham el ProductsList
            //xosq@ gnum e Creat Viewi meji @modeli masin

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.ProductTypes = _dbContext.ProductType.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ProductTypes = _dbContext.ProductType.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);

            ViewBag.ProductTypes = _dbContext.ProductType.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            if (product != null)
            {
                ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ProductTypes = _dbContext.ProductType.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }
    }
}
