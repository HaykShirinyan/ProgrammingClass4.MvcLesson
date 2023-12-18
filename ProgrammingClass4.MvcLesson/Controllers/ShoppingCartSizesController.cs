using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
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
            var shoppingCartSizes = _dbContext.ShoppingCartSizes
                .Include(shoppingCartSizes =>  shoppingCartSizes.Size)
                .Where(shoppingCartSizes => shoppingCartSizes.ShoppingCartId == shoppingCartId)
                .ToList();

            var shoppingCartSizeViewModel = new ShoppingCartSizeViewModel
            {
                ShoppingCart = _dbContext.ShoppingCarts.Find(shoppingCartId),
                Sizes = _dbContext.Sizes.ToList(),
                ShoppingCartSizes = shoppingCartSizes,
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
