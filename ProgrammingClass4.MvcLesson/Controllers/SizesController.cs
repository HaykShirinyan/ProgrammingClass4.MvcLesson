using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class SizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
           List<Size> sizes = _dbContext.Sizes.ToList();
            return View(sizes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Size size)
        {
           if (ModelState.IsValid)
            {
                _dbContext.Sizes.Add(size);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(size);
        }   

        public IActionResult Edit(int id)
        {
            var size = _dbContext.Sizes.Find(id);
            if(size!=null)
            {
                return View(size);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Size size) 
        { 
            if(ModelState.IsValid)
            {
                _dbContext.Sizes.Update(size);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(size);
        
        }

    }
}
