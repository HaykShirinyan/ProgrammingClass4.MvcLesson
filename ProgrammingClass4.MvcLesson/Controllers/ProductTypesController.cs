using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductTypesController(ProductTypesController dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<ProductTypes>productTypes = _dbContext.ProductTypes.ToList();//_dbContext fieldi ognutyamb ProductTypes list@ vercnum enq u dnum enq productTypes popoxakani mej
            //poxancum enq Viewin productTypes@,tvyalner@ poxancecinq View(ProductTypes) folderin

            return View(productTypes);
        }
    }
}
