using MyDutchUncle.Core.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDutchUncle.DataAccess.Abstractions.Repos
{
    public interface IAccountRepo
    {
        int CreateAccount(AccountDto accountDto);
        AccountDto Load(int acctId);
        Task<IEnumerable<AccountDto>> LoadAll();
        bool DeleteAccount(int acctId);
    }
}
