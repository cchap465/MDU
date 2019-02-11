using MyDutchUncle.Core.DataTransferObjects;
using MyDutchUncle.DataAccess.Abstractions.Repos;
using MyDutchUncle.Transport.Abstractions.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDutchUncle.Transport.Handlers
{
    public class AccountCreationHandler : IAccountCreationHandler
    {
        #region Privates
        private readonly IAccountRepo _accountRepo;
        #endregion

        #region Constructors
        public AccountCreationHandler(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        #endregion

        public int Create(AccountDto accountDto)
        {
            return _accountRepo.CreateAccount(accountDto);
        }

        public async Task<IEnumerable<AccountDto>> LoadAccounts()
        {
            return await _accountRepo.LoadAll();
        }

        public AccountDto LoadAccountById(int acctId)
        {
            return _accountRepo.Load(acctId);
        }

        public bool DeleteAccountById(int acctId)
        {
            return _accountRepo.DeleteAccount(acctId);
        }
    }
}
