using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ColorsController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Color> color = _dbContext.Colors.ToList();

            return View(color);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color) //save
        {
            if (ModelState.IsValid)
            {
                _dbContext.Colors.Add(color);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(color);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var color = _dbContext.Colors.Find(id);

            if (color != null)
            {
                return View(color);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Color color)//save
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