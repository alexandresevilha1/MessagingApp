using System.Threading.Tasks;
using MessagingApp.Application.DTOs;

namespace MessagingApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterUserDTO registerDto);
        Task<bool> LoginAsync(LoginDTO loginDto);
        Task LogoutAsync();
    }
}