using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCart = _dbContext.shoppingCarts.ToList();

            return View(shoppingCart);
        }
    }
}
