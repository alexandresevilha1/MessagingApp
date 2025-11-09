using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MessagingApp.WebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Chat(Guid userId)
        {
            var currentUserIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserIdStr))
            {
                return RedirectToAction("Login", "Account");
            }
            var currentUserId = Guid.Parse(currentUserIdStr);

            var targetUser = await _userService.GetByIdAsync(userId);
            if (targetUser == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var messages = await _messageService.GetConversationHistoryAsync(currentUserId, targetUser.Id);

            var viewModel = new ChatViewModel
            {
                CurrentUserId = currentUserId,
                TargetUserId = targetUser.Id,
                TargetUserName = $"{targetUser.FirstName} {targetUser.LastName}",
                Messages = messages
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatViewModel model)
        {
            var currentUserIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserIdStr))
            {
                return RedirectToAction("Login", "Account");
            }
            var currentUserId = Guid.Parse(currentUserIdStr);
            if (string.IsNullOrWhiteSpace(model.NewMessageContent))
            {
                ModelState.AddModelError(string.Empty, "A mensagem não pode estar vazia.");
                return RedirectToAction("Chat", new { userId = model.TargetUserId });
            }
            var messageDto = new MessageDto
            {
                SenderId = currentUserId,
                ReceiverId = model.TargetUserId,
                Content = model.NewMessageContent,
                SentAt = DateTime.UtcNow
            };
            await _messageService.SendMessageAsync(messageDto);
            return RedirectToAction("Chat", new { userId = model.TargetUserId });
        }
    }
}