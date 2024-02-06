using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Data.Migrations;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    
    public class ShoppingCartColorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int shoppingCartId)
        {
            var shoppingCart = _dbContext.ShoppingCarts
                .Include(cart => cart.Product)
                .FirstOrDefault(cart => cart.Id == shoppingCartId);

            if (shoppingCart == null)
            {
                return NotFound();
            }
            shoppingCart.Product.ImageUrl = $"/images/products/{shoppingCart.Product.Name.Replace(" ", "-").ToLower()}.jpg";
            
            var productColors = _dbContext.ProductColors
                .Where(pc => pc.ProductId == shoppingCart.ProductId)
                .Include(pc => pc.Color)
                .Select(pc => pc.Color)
                .ToList();

            var shoppingCartColors = _dbContext
                .ShoppingCartColors
                .Include(shoppingCartColor => shoppingCartColor.Color)
                .Where(shoppingCartColor => shoppingCartColor.ShoppingCartId == shoppingCartId)
                .ToList();

            var shoppingCartColorViewModel = new ShoppingCartColorViewModel
            {
                ShoppingCart = shoppingCart,
                Colors = productColors,
                ShoppingCartColors = shoppingCartColors,
            };

            return View(shoppingCartColorViewModel);
        }

        [HttpPost]
        public IActionResult Create(ShoppingCartColorViewModel shoppingCartColorViewModel)
        {
            var existingColor = _dbContext.ShoppingCartColors
                 .FirstOrDefault(s => s.ShoppingCartId == shoppingCartColorViewModel.ShoppingCartColor.ShoppingCartId);

            if (existingColor != null) 
            {
                return RedirectToAction("Index", new { shoppingCartId = shoppingCartColorViewModel.ShoppingCartColor.ShoppingCartId });
            }

            _dbContext.ShoppingCartColors.Add(shoppingCartColorViewModel.ShoppingCartColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new {shoppingCartId = shoppingCartColorViewModel.ShoppingCartColor.ShoppingCartId });
        }

        [HttpPost]
        public IActionResult RemoveItem(int shoppingCartId, int colorId)
        {
            var shoppingCartColor = _dbContext.ShoppingCartColors
                .FirstOrDefault(s => s.ShoppingCartId == shoppingCartId && s.ColorId == colorId );

            if (shoppingCartColor != null)
            {
                _dbContext.ShoppingCartColors.Remove(shoppingCartColor);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { shoppingCartId });
        }
    }
}
