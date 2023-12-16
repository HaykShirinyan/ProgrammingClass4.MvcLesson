using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
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

            var productViewModel = new ProductViewModel
            {
                ProductTypes = _dbContext.ProductType.ToList(),
            };


            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            productViewModel.ProductTypes = _dbContext.ProductType.ToList();

            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var productViewModel = new ProductViewModel
            {
                Product = _dbContext.Products.Find(id),
                ProductTypes = _dbContext.ProductType.ToList()

            };

            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();
            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

                return View(productViewModel);
 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid) //  
            {
                _dbContext.Products.Update(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.ProductTypes = _dbContext.ProductType.ToList();

            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();
            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var productViewModel = new ProductViewModel
            {
                Product = _dbContext.Products.Find(id),
            };

            return View(productViewModel);
        }
    }
}
