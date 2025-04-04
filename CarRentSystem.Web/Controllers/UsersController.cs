using CarRentSystem.Data.Entities;
using CarRentSystem.Services.Contracts;
using CarRentSystem.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRentSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController(IUserService userService, UserManager<User> userManager) : Controller
    {
        private readonly IUserService _userService = userService;
        private readonly UserManager<User> _userManager = userManager;

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel, string password)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            try
            {
                await _userService.AddAsync(userModel, password);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userModel);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}