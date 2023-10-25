using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    
    public class ProductShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()//asec sxala sranov karas mtnes et qart bayc,voch ban avelacnes ? indexov mtnel ej
        {
            var productShoppingCarts = _dbContext
                .ProductShoppingCarts
                .Include(productShoppingCart => productShoppingCart.ShoppingCart)
                .ToList();

            return View(productShoppingCarts);
        }
    }
}
