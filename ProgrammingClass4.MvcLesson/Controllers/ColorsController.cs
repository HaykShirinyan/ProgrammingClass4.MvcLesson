using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {

        private ApplicationDbContext _dbContext;

        public ColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            var colors = _dbContext.Colors.ToList();
            return View(colors);
        }

        public IActionResult Create() 
        { 
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Color color) 
        { 
            if(ModelState.IsValid)
            {
                _dbContext.Colors.Add(color);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }   
            return View(color);
        }

        public IActionResult Edit(int id)
        {
            var color = _dbContext.Colors.Find(id);
            if(color != null)
            {
                return View(color);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Colors.Update(color);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(color);
        }
   
    }
}
