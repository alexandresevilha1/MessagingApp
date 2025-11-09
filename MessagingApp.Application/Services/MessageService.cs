using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using MessagingApp.Domain.Interfaces;

namespace MessagingApp.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendMessageAsync(MessageDto messageDto)
        {
            var message = new Message(messageDto.SenderId, messageDto.ReceiverId, messageDto.Content);
            await _messageRepository.CreateMessageAsync(message);
        }

        public async Task<IEnumerable<MessageDto>> GetConversationHistoryAsync(Guid user1Id, Guid user2Id)
        {
            var messages = await _messageRepository.GetMessagesBetweenUsersAsync(user1Id, user2Id);
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                SenderId = m.SenderId,
                SenderName = $"{m.Sender.FirstName} {m.Sender.LastName}",
                ReceiverId = m.ReceiverId,
                ReceiverName = $"{m.Receiver.FirstName} {m.Receiver.LastName}",
                Content = m.Content,
                SentAt = m.SentAt
            });
        }
    }
}