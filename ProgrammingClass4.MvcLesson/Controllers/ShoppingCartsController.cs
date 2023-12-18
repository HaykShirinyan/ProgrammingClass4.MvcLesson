using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProgrammingClass4.MvcLesson.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        
        public ShoppingCartsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IActionResult Index()
        {
           
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = _dbContext.ShoppingCarts
            
                .Where(cartItem => cartItem.UserId == userId)
                .Select(cartItem => new ShoppingCartViewModel
                {
                    CartItemId = cartItem.Id,
                    Product = cartItem.Product,
                    Quantity = cartItem.Quantity,
                    SelectedColorName = _dbContext.ShoppingCartColors
                   .Where(c => c.ShoppingCartId == cartItem.Id)
                   .Select(c => c.Color.Name)
                   .FirstOrDefault(),
                    SelectedSizeName = _dbContext.ShoppingCartSizes
                    .Where(s => s.ShoppingCartId == cartItem.Id)
                    .Select(s => s.Size.Name)
                    .FirstOrDefault(),
                })
                .ToList();

            return View(cartItems);
        }


        [HttpPost]
        [Authorize]
        public IActionResult AddToCart(int productId)
        {
          
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            
            if (product == null )
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existingCartItem = _dbContext.CartItems
                .FirstOrDefault(cartItem => cartItem.UserId == userId &&
                cartItem.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;

            }
            else
            {
                var newCartItem = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1,
                };
                

                _dbContext.ShoppingCarts.Add(newCartItem);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public  IActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = _dbContext.ShoppingCarts.FirstOrDefault(c => c.Id == cartItemId);
            if (cartItem != null)
            {
                _dbContext.ShoppingCarts.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewColors(int shoppingCartId)
        {
            return RedirectToAction("Index", "ShoppingCartColors", new { shoppingCartId });
        }

        [HttpGet]
        public IActionResult ViewSizes(int shoppingCartId)
        {
            return RedirectToAction("Index", "ShoppingCartSizes", new {shoppingCartId});
        }

        [HttpPost]
        [Authorize]
        public IActionResult Buy()
        {
            TempData["BuyMessage"] = "Congratulations! Your purchase is complete.";

            return RedirectToAction("Index");
        }
    }
}
