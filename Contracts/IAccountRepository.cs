using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(Account account);

        Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackingChanges);
    }
}
