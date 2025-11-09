using Microsoft.AspNetCore.Mvc;
using MessagingApp.Application.Interfaces;
using MessagingApp.Application.DTOs;

namespace MessagingApp.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var success = await _authService.RegisterAsync(registerDto);
            if (success)
            {
                return RedirectToAction("Login");
            }

            return View(registerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var success = await _authService.LoginAsync(loginDto);
            if(success)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(loginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
