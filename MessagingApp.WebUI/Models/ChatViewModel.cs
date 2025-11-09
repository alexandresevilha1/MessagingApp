using System;
using System.Collections.Generic;
using MessagingApp.Application.DTOs;

namespace MessagingApp.WebUI.Models
{
    public class ChatViewModel
    {
        public Guid CurrentUserId { get; set; }
        public Guid TargetUserId { get; set; }
        public string TargetUserName { get; set; }

        public IEnumerable<MessageDto> Messages { get; set; }

        public string NewMessageContent { get; set; }
    }
}