using Mail.Entities;
using Mail.Models;

namespace Mail.Service.IService;

public interface IMessageService
{
    public Task<List<MessageDisplayModel>> GetAllReceivedMessage(int reciplientId);

    public Task<List<MessageDisplayModel>> GetAllSendedMessage(int senderId);

    public Task AddMessage(MessagesInfo msg);
}