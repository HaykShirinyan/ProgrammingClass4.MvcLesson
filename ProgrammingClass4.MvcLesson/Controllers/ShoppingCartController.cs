using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using System.Security.Claims;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private string CurrentUserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            }
        }

        public ShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cartProducts = _dbContext
                .ShoppingCartProducts
                .Include(cartProduct => cartProduct.Product)
                .Where(cartProduct => cartProduct.UserId == CurrentUserId)
                .ToList();

            return View(cartProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int id)
        {
            var cartProduct = _dbContext
                .ShoppingCartProducts
                .SingleOrDefault(cartProduct => cartProduct.UserId == CurrentUserId && cartProduct.ProductId == id);

            if (cartProduct == null)
            {
                cartProduct = new ShoppingCartProduct
                {
                    UserId = CurrentUserId,
                    ProductId = id
                };

                _dbContext.ShoppingCartProducts.Add(cartProduct);
            }

            cartProduct.Quantity = cartProduct.Quantity + 1;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cartProduct = _dbContext
                .ShoppingCartProducts
                .Single(cartProduct => cartProduct.UserId == CurrentUserId && cartProduct.ProductId == id);

            _dbContext.ShoppingCartProducts.Remove(cartProduct);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
