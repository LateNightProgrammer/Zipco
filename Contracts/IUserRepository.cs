using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);

        Task<User> GetUserAsync(int userId, bool trackChanges);

        Task<User> FindUserByEmail(string email);

        Task CreateUserAsync(User user);
    }
}
