using Mail.Entities;

namespace Mail.Models
{
    public class MessageDisplayModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public DateTime? DispatchTime { get; set; }

        public string? SenderName { get; set; }

        public string? RecipientName { get; set; }
    }
}
