using MessagingApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MessagingApp.Application.Interfaces;
using MessagingApp.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace MessagingApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();

            var myEmail = User.Identity.Name;
            users = users.Where(u => u.Email != myEmail);

            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
