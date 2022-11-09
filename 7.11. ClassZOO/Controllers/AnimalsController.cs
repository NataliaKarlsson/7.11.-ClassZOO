using _7._11._ClassZOO.Models;
using _7._11._ClassZOO.Models.repos;
using _7._11._ClassZOO.Models.Servises;
using _7._11._ClassZOO.Models.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace _7._11._ClassZOO.Controllers
{
    public class AnimalsController : Controller
    {
        IAnimalsService _animalsService;

        public AnimalsController()
        {
            _animalsService = new AnimalsService(new InMemoryRepo());

        }
        
        public IActionResult ZooPark()
        {
            return View(_animalsService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateAnimalsViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateAnimalsViewModel createAnimal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _animalsService.Create(createAnimal);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Animal & species", exception.Message);
                    return View(createAnimal);
                }
                return RedirectToAction(nameof(ZooPark));
            }
            return View(createAnimal);
        }
        public IActionResult Details(int id)
        {
            Animals animal = _animalsService.FindById(id);
            if(animal != null)
            {
                return RedirectToAction(nameof(ZooPark));
            }
            return View(animal);
        }
        public IActionResult LastAnimalArrivel()
        {
            Animals animal = _animalsService.LastAdded();
            if (animal != null)
            {
                return PartialView("_AnimalRow", animal);
            }
            return NotFound();
        }
        public IActionResult AjaxAnimalList()
        {
            List<Animals> animal = _animalsService.GetAll();

            if (animal != null)
            {
                return PartialView("_AnimalList", animal);
            }
            return BadRequest();
        }
        public IActionResult LastAnimalArrivelJSON()
        {
            Animals animal = _animalsService.LastAdded();
            if (animal != null)
            {
                return Json(animal);
            }
            return NotFound();
        }
    }
}
