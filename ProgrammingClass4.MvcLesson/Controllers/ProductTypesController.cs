using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesController(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();
            
            return View(productTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType) 
        { 
            if(ModelState.IsValid) 
            { 
                _dbContext.ProductTypes.Add(productType);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            
            }
            
            return View(productType);
        }

        public IActionResult Edit(int id)
        {
            var productType =_dbContext.ProductTypes.Find(id);

            if(productType != null) 
            { 
                return View(productType);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType) 
        {
            if (ModelState.IsValid) 
            { 
                _dbContext.ProductTypes.Update(productType);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }
            
            return View(productType);
        }
    }
}
