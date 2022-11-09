using _7._11._ClassZOO.Models;
using _7._11._ClassZOO.Models.repos;
using _7._11._ClassZOO.Models.Servises;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _7._11._ClassZOO.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IAnimalsService _animalsService;
        

        public HomeController()
        {
            _animalsService = new AnimalsService(new InMemoryRepo());
        }

        public IActionResult Index()
        {
            return View(_animalsService.LastAdded());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}