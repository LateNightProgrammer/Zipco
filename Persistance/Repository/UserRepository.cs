using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ZipcoContext zipcoContext) :base(zipcoContext)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
            => await FindAll(trackChanges).OrderBy(o => o.Name).ToListAsync();
        

        public async Task<User> GetUserAsync(int userId, bool trackChanges) 
            => await FindByCondition(u=> 
                u.Id.Equals(userId), trackChanges).FirstOrDefaultAsync();

        public async Task<User> FindUserByEmail(string email)
        => await FindByCondition(u=> 
            u.Email.Equals(email,StringComparison.InvariantCultureIgnoreCase), false).FirstOrDefaultAsync();
        
        public async Task CreateUserAsync(User user)
        {
             await ZipcoContext.Users.AddAsync(user);
        }
    }
}
