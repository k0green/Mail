using Mail.Context;
using Mail.Entities;
using Mail.Models;
using Mail.Repository;
using Mail.Repository.IRepository;
using Mail.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace Mail.Service
{
    public class MessageService : IMessageService
    {

        IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<MessageDisplayModel>> GetAllReceivedMessage(int reciplientId)
        {
            return await _messageRepository.GetAllReceivedMessage(reciplientId);
        }

        public async Task<List<MessageDisplayModel>> GetAllSendedMessage(int senderId)
        {
            return await _messageRepository.GetAllSendedMessage(senderId);
        }

        public async Task AddMessage(MessagesInfo msg)
        {
           await _messageRepository.AddMessage(msg);
        }
    }
}
