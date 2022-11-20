using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class AccountRepository: RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ZipcoContext zipcoContext) : base(zipcoContext)
        {
        }

        public async Task CreateAccountAsync(Account account)
        {
            await ZipcoContext.Account.AddAsync(account);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChanges)
            => await FindAll(trackChanges).ToListAsync();

    }
}
