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
        
        public IActionResult Index()
        {
            List<UnitOfMeasure> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();
            
            return View(unitOfMeasures);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure) 
        { 
            if(ModelState.IsValid) 
            { 
                _dbContext.UnitOfMeasures.Add(unitOfMeasure);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(unitOfMeasure);
        }

        public IActionResult Edit(int id) 
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.Find(id);
            if(unitOfMeasure != null) 
            { 
                return View(unitOfMeasure);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(UnitOfMeasure measure) 
        {
            if(ModelState.IsValid) 
            { 
                _dbContext.UnitOfMeasures.Update(measure);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }

            return View(measure);
        }


    }
}
