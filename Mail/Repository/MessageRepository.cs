using Mail.Context;
using Mail.Context.IContext;
using Mail.Entities;
using Mail.Models;
using Mail.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mail.Repository
{
    public class MessageRepository : IMessageRepository
    {
        ITask6Context _context;

        public MessageRepository(ITask6Context context) 
        {
            _context = context;
        }

        public async Task<List<MessageDisplayModel>> GetAllReceivedMessage(int reciplientId)
        {
            var msgs = await _context.MessagesInfos.Where(x => x.RecipientId == reciplientId).Select(x => new MessageDisplayModel
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                DispatchTime = x.DispatchTime,
                SenderName = x.Sender.Name,
                RecipientName = x.Recipient.Name
            }).ToListAsync();
            return msgs;
        }

        public async Task<List<MessageDisplayModel>> GetAllSendedMessage(int senderId)
        {
            var msgs = await _context.MessagesInfos.Where(x => x.SenderId == senderId).Select(x => new MessageDisplayModel
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                DispatchTime = x.DispatchTime,
                SenderName = x.Sender.Name,
                RecipientName = x.Recipient.Name
            }).ToListAsync();
            return msgs;
        }

        public async Task AddMessage(MessagesInfo msg)
        {
            await _context.MessagesInfos.AddAsync(msg);
            _context.SaveChanges();
        }
    }
}
