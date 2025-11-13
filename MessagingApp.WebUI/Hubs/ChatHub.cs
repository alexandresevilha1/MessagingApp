using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace MessagingApp.WebUI.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public ChatHub(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task SendMessage(Guid targetUserId, string content)
        {
            var senderIdStr = Context.UserIdentifier;
            var senderId = Guid.Parse(senderIdStr);

            var sender = await _userService.GetByIdAsync(senderId);
            var receiver = await _userService.GetByIdAsync(targetUserId);

            if (sender == null || receiver == null)
            {
                throw new InvalidOperationException("Usuário remetente ou destinatário não encontrado.");
            }

            var messageDto = new MessageDto
            {
                SenderId = sender.Id,
                SenderName = $"{sender.FirstName} {sender.LastName}",
                ReceiverId = receiver.Id,
                ReceiverName = $"{receiver.FirstName} {receiver.LastName}",
                Content = content,
                SentAt = DateTime.UtcNow
            };

            await _messageService.SendMessageAsync(messageDto);

            await Clients.User(targetUserId.ToString()).SendAsync("ReceiveMessage", messageDto);

            await Clients.User(senderIdStr).SendAsync("ReceiveMessage", messageDto);
        }
    }
}