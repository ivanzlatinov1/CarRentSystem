using Microsoft.AspNetCore.Mvc;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentSystem.Web.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class RentsController(IRentService rentService, ICarService carService, IUserService userService) : Controller
    {
        private readonly IRentService _rentService = rentService;
        private readonly ICarService _carService = carService;
        private readonly IUserService _userService = userService;

        // GET: /Rents
        public async Task<IActionResult> Index()
        {
            var rents = await _rentService.GetAllAsync();

            return View(rents);
        }

        // GET: /Rents/Details?userId=abc&carId=1
        public async Task<IActionResult> Details(string userId, int carId)
        {
            var rent = await _rentService.GetByIdAsync(userId, carId);

            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: /Rents/Edit
        public IActionResult Edit(string userId, int carId)
        {
            return View();
        }

        // POST: /Rents/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RentModel rentModel)
        {
            if (!ModelState.IsValid)
            {
                return View(rentModel);
            }

            await _rentService.UpdateAsync(rentModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Rents/Rent
        public async Task<IActionResult> Rent()
        {
            var users = await _userService.GetAllAsync();
            var cars = await _carService.GetAllAsync();

            ViewBag.Users = users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.Username
            }).ToList();

            ViewBag.Cars = cars.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Make} {c.Model}, year: {c.Year}"
            }).ToList();

            return View();
        }

        // POST: /Rents/Rent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(string userId, int carId)
        {
            var result = await _rentService.RentCarAsync(userId, carId);
            string errorMessage = "Car is already rented.";

            if (result == errorMessage)
            {
                await FillDropdowns();
                ModelState.AddModelError("", errorMessage);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Rents/Return
        public async Task<IActionResult> Return()
        {
            var rentedCars = await _rentService.GetAllAsync();
            var userRentedCars = rentedCars.Where(r => r.UserId == User.Identity?.Name && r.ReturnDate == null).ToList();

            ViewBag.Cars = userRentedCars.Select(c => new SelectListItem
            {
                Value = c.CarId.ToString(),
                Text = $"{c.Car.Make} {c.Car.Model}, year: {c.Car.Year}"
            }).ToList();

            return View();
        }

        // POST: /Rents/Return
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int carId)
        {
            var result = await _rentService.ReturnCarAsync(User.Identity.Name, carId);

            if (result == "The car is not rented or it has already been returned.")
            {
                ModelState.AddModelError("", "The car is not rented or it has already been returned.");
                await FillDropdowns();
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Rents/Delete
        public IActionResult Delete(string userId, int carId)
        {
            return View(); // Views/Rents/Delete.cshtml
        }

        // POST: /Rents/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RentModel rentModel)
        {
            await _rentService.DeleteAsync(rentModel);
            return RedirectToAction(nameof(Index));
        }

        // Helper method
        private async Task FillDropdowns()
        {
            var users = await _userService.GetAllAsync();
            var cars = await _carService.GetAllAsync();

            ViewBag.Users = users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.Username
            }).ToList();

            ViewBag.Cars = cars.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Make} {c.Model}, year: {c.Year}"
            }).ToList();
        }
    }
}
