using Mail.Entities;

namespace Mail.Repository.IRepository;

public interface IUserRepository
{
    public Task<List<User>> GetAllUser();
    public Task<User> GetUserByName(string username);

    public Task AddUser(User user);
}