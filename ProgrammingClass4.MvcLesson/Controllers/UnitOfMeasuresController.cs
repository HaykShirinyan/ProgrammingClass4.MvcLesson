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
    }
}
