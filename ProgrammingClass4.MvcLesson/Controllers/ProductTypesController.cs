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
    }
}
