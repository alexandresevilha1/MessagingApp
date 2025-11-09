using MessagingApp.Domain.Entities;

namespace MessagingApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> FindUserByIdAsync(Guid id);
        Task<User> FindUserByEmailAsync(string email);
    }
}