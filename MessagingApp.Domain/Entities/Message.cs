namespace MessagingApp.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; private set; }

        public Guid SenderId { get; private set; }
        public User Sender { get; private set; }

        public Guid ReceiverId { get; private set; }
        public User Receiver { get; private set; }

        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }

        protected Message() { }

        public Message(Guid senderId, Guid receiverId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new Exception("Message content cannot be empty.");

            Id = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            SentAt = DateTime.UtcNow;
        }
    }
}