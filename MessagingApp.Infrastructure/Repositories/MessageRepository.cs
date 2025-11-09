using MessagingApp.Domain.Entities;
using MessagingApp.Domain.Interfaces;
using MessagingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Message> CreateMessageAsync(Message message)
        {
            var messageEntry = await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return messageEntry.Entity;
        }

        public async Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(Guid userId1, Guid userId2)
        {
            var messages = await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => (m.SenderId == userId1 && m.ReceiverId == userId2) ||
                            (m.SenderId == userId2 && m.ReceiverId == userId1))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return messages;
        }
    }
}
