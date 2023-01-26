using Mail.Entities;

namespace Mail.Service.IService;

public interface IUserService
{
    public Task<List<User>> GetAllUser();
    public Task<User> GetUserByName(string username);

    public Task AddUser(User user);
}