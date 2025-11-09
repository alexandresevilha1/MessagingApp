using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessagingApp.Application.DTOs;

namespace MessagingApp.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(MessageDto messageDto);
        Task<IEnumerable<MessageDto>> GetConversationHistoryAsync(Guid user1Id, Guid user2Id);
    }
}