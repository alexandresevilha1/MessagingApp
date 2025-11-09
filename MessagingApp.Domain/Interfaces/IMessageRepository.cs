using MessagingApp.Domain.Entities;

namespace MessagingApp.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(Guid userId1, Guid userId2);
    }
}
