using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Data.Migrations;
using ProgrammingClass4.MvcLesson.Models;
using ProgrammingClass4.MvcLesson.ViewModels;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;


namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        

        public IActionResult Index()
        {
           return View();
        }

        public IActionResult Shop()
        {
            var products = _dbContext.Products.ToList();
            var productViewModel = new ProductViewModel
            {
                Products = products
            };

            
            return View(productViewModel);

        }

        public IActionResult About() 
        {
            return View();
        }

        public IActionResult Contuct() 
        {
            return View();
        }

        public IActionResult Menu() 
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
                return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product != null)
            {
                var productViewModel = new ProductViewModel
                {
                    Product = product,
                    ProductTypes = _dbContext.ProductTypes.ToList(),
                    Manufacturers = _dbContext.Manufacturers.ToList(),
                    UnitOfMeasures = _dbContext.UnitOfMeasures.ToList(),
                    Colors = _dbContext.Colors.ToList(),
                    Sizes = _dbContext.Sizes.ToList(),
                };
                return View(productViewModel);
            }

            return NotFound();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}