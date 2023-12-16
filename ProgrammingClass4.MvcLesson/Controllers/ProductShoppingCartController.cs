using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Data.Migrations;
using ProgrammingClass4.MvcLesson.Models;
using System.Security.Claims;
using System.Security.Principal;
using ProductShoppingCart = ProgrammingClass4.MvcLesson.Models.ProductShoppingCart;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Route("ProductShoppingCart")]
    public class ProductShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var productShoppingCarts = _dbContext
                .ProductShoppingCarts
                .Include(productShoppingCart => productShoppingCart.Product)
                .Where(productShoppingCart => productShoppingCart.ShoppingCart.UserId == userId)
                .ToList();

            return View(productShoppingCarts);
        }


        [HttpPost("{productId}")]
        public IActionResult AddToCart(int productId)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _dbContext.Products.Find(productId);

            if (product != null )
            {
                var shoppingCart = _dbContext.shoppingCarts.FirstOrDefault(cart => cart.UserId == userId);

                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart
                    {
                        UserId = userId,
                        Name = "Test cart"
                    };

                    _dbContext.shoppingCarts.Add(shoppingCart);
                }

                var productShoppingCart = new ProductShoppingCart
                {
                    Product = product,
                    ShoppingCart = shoppingCart
                };

                _dbContext.ProductShoppingCarts.Add(productShoppingCart);
                _dbContext.SaveChanges();

                TempData["CartCount"] = _dbContext.ProductShoppingCarts
                .Count(cartItem => cartItem.ShoppingCart.UserId == userId);

                return RedirectToAction("Details", "Products", new { id = productId });
            }

                return RedirectToAction("Details", "Products");

        }
    }

}
