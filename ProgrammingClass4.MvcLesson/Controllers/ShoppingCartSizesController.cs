using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ShoppingCartSizesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartSizesController(ApplicationDbContext dbContext)
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

            var productSizes = _dbContext.ProductSizes
                .Where(pc => pc.ProductId == shoppingCart.ProductId)
                .Include(pc => pc.Size)
                .Select(pc => pc.Size)
                .ToList();

            var shoppingCartSize = _dbContext
                .ShoppingCartSizes
                .Include(shoppingCartSize => shoppingCartSize.Size)
                .Where(shoppingCartSize => shoppingCartSize.ShoppingCartId == shoppingCartId)
                .ToList();

            var shoppingCartSizeViewModel = new ShoppingCartSizeViewModel
            {
                ShoppingCart = shoppingCart,
                Sizes = productSizes,
                ShoppingCartSizes = shoppingCartSize,
            };
            
            return View(shoppingCartSizeViewModel);
        }

        [HttpPost]
        public IActionResult Create(ShoppingCartSizeViewModel shoppingCartSizeViewModel)
        {
            var existingSize = _dbContext.ShoppingCartSizes
                .FirstOrDefault(s => s.ShoppingCartId == shoppingCartSizeViewModel.ShoppingCartSize.ShoppingCartId);

            if (existingSize != null)
            {
                return RedirectToAction("Index", new {shoppingCartId = shoppingCartSizeViewModel.ShoppingCartSize.ShoppingCartId});
            }

            _dbContext.ShoppingCartSizes.Add(shoppingCartSizeViewModel.ShoppingCartSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { shoppingCartId = shoppingCartSizeViewModel.ShoppingCartSize.ShoppingCartId });
        }

        [HttpPost]
        public IActionResult RemoveItem(int shoppingCartId, int sizeId) 
        {
            var shoppingCartSize = _dbContext.ShoppingCartSizes
                .FirstOrDefault(s => s.ShoppingCartId == shoppingCartId && s.SizeId == sizeId);

            if(shoppingCartSize != null)
            {
                _dbContext.ShoppingCartSizes.Remove(shoppingCartSize);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { shoppingCartId });
        }
    }
}
