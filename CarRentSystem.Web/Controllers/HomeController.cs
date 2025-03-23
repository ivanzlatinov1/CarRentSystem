using System.Diagnostics;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentSystem.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICarService carService, IUserService userService,
        IRentService rentService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICarService _carService = carService;
        private readonly IUserService _userService = userService;
        private readonly IRentService _rentService = rentService;

        public IActionResult Index()
        {
            ViewData["CarsCount"] = _carService.GetAllAsync().Result.Count;
            ViewData["UsersCount"] = _userService.GetAllAsync().Result.Count;
            ViewData["RentsCount"] = _rentService.GetAllAsync().Result.Count;

            return View();
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
