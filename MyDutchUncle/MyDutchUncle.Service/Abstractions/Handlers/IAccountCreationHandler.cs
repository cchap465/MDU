using MyDutchUncle.Core.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDutchUncle.Transport.Abstractions.Handlers
{
    public interface IAccountCreationHandler
    {
        int Create(AccountDto accountDto);
        AccountDto LoadAccountById(int acctId);
        Task<IEnumerable<AccountDto>> LoadAccounts();
        bool DeleteAccountById(int acctId);
    }
}
