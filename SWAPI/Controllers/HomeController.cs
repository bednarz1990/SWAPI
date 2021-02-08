using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWAPI.Services.Interfaces;
using SWAPI.ViewModels;

namespace SWAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISwapiService _swapiService;

        public HomeController(ILogger<HomeController> logger, ISwapiService swapiService)
        {
            _logger = logger;
            _swapiService = swapiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Films()
        {
            // TODO Logging
            var result = _swapiService.GetAllFilms().Result;
            return View(result);
        }

        public IActionResult Rank(Result vm)
        {
            // TODO model validation
            return View(vm);
        }

        public IActionResult Rate(int id, int rate)
        {
            var isSaved = _swapiService.SaveRate(id, rate);
            if (isSaved)
            {
                TempData["Success"] = true;
                return RedirectToAction("Success");
            }

            TempData["Error"] = true;
            return RedirectToAction("Error");
        }

        public IActionResult Details(Result vm)
        {
            return View(vm);
        }

        public IActionResult Success()
        {
            ViewBag.Success = TempData["Success"] as bool? ?? false;
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Error = TempData["Error"] as bool? ?? false;
            return View();
        }
    }
}