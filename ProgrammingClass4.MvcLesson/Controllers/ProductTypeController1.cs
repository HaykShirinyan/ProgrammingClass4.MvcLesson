using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ProductTypeController1 : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductTypeController1(ProductTypeController1 dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<ProductTypes>productTypes=_dbContext.ProductTypes.ToList();

            return View(productTypes);
        }
    }
}
