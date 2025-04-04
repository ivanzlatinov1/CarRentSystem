using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController(ICarService service) : Controller
    {
        private readonly ICarService _service = service;

        // GET: Cars
        [AllowAnonymous]
        public async Task<IActionResult> Index(string search)
        {
            ICollection<CarModel>? cars;

            if (!string.IsNullOrEmpty(search))
                cars = await _service.FindByMake(search);
            else
                cars = await _service.GetAllAsync();

            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel? car = await _service.GetByIdAsync(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Make,Model,Year,Seats,Description,Price,ImageUrl,Id")] CarModel car)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel? car = await _service.GetByIdAsync(id.Value);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Make,Model,Year,Seats,Description,Price,ImageUrl,Id")] CarModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(car.Id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _service.GetByIdAsync(car.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel? car = await _service.GetByIdAsync(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CarModel? car = await _service.GetByIdAsync(id);
            if (car != null)
            {
                await _service.RemoveAsync(car.Id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
