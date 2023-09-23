using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ProductTypesController1 : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductTypesController1(ProductTypesController1 dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<ProductTypes>productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }
    }
}
