using Mail.Context;
using Mail.Entities;
using Mail.Repository;
using Mail.Repository.IRepository;
using Mail.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace Mail.Service
{
    public class UserService : IUserService
    {

        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        public async Task<User> GetUserByName(string username)
        {
            return await _userRepository.GetUserByName(username);
        }

        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(user);
        }
    }
}
