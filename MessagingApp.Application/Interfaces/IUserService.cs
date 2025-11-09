using System;
using System.Threading.Tasks;
using MessagingApp.Application.DTOs;

namespace MessagingApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByEmailAsync(string email);
    }
}