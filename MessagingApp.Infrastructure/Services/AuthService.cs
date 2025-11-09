using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using MessagingApp.Domain.Interfaces;
using MessagingApp.Infrastructure.Identity;

namespace MessagingApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterUserDTO registerDto)
        {
            var identityUser = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(identityUser, registerDto.Password);
            if (result.Succeeded)
            {
                var user = new User(
                    registerDto.FirstName,
                    registerDto.LastName,
                    registerDto.DateOfBirth,
                    registerDto.Gender,
                    registerDto.CountryOfOrigin,
                    registerDto.Email
                );
                await _userRepository.CreateUserAsync(user);
                return true;
            }
            return false;
        }
    }
}