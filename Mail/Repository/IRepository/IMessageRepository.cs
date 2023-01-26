using Mail.Entities;
using Mail.Models;
using Microsoft.EntityFrameworkCore;

namespace Mail.Repository.IRepository
{
    public interface IMessageRepository
    {
        public Task<List<MessageDisplayModel>> GetAllReceivedMessage(int reciplientId);

        public Task<List<MessageDisplayModel>> GetAllSendedMessage(int senderId);

        public Task AddMessage(MessagesInfo msg);
    }
}
