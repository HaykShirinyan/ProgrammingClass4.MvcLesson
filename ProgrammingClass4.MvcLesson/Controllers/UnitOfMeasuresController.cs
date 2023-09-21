using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using ProgrammingClass4.MvcLesson.Models;


namespace ProgrammingClass4.MvcLesson.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private ApplicationDbContext _dbContext;
        public UnitOfMeasuresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UnitOfMeasures> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitOfMeasures unit)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Add(unit);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(unit);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unit = _dbContext.UnitOfMeasures.Find(id);
            if (unit != null)
            {
                return View(unit);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(UnitOfMeasures unit) 
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Update(unit);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(unit);  
             
        }

    }
}
