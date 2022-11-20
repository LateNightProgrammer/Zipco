using System.Threading.Tasks;
using Contracts;

namespace Persistence.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ZipcoContext _zipcoContext;
        private IUserRepository _userRepository;
        private IAccountRepository _accountRepository;

        public RepositoryManager(ZipcoContext zipcoContext)
        {
            _zipcoContext = zipcoContext;
        }

        public IUserRepository User => _userRepository ?? new UserRepository(_zipcoContext);

        public IAccountRepository Account => _accountRepository ?? new AccountRepository(_zipcoContext);

        public async Task  SaveAsync() => await _zipcoContext.SaveChangesAsync();
       
    }
}
