using MyDutchUncle.Core.DataTransferObjects;
using MyDutchUncle.DataAccess.Abstractions.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDutchUncle.DataAccess.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly List<AccountDto> accountDtos = new List<AccountDto>();

        public AccountRepo()
        {
            for (int i = 0; i < 50; i++)
            {
                AccountDto accountDto = new AccountDto()
                {
                    AcctId = i,
                    UserName = $"testDataUser{i}",
                    FirstName = $"testDataFirstName{i}",
                    LastName = $"testDataLastName{i}",
                    Email = $"testDataEmail{i}@test.com",
                    EmailConfirmed = true,
                    Password = $"testPassword{i}"
                };

                accountDto.SecurityQuestions.Add(Core.Enums.SecurityQuestionCategories.MothersMaidenName, i.ToString());

                accountDtos.Add(accountDto);                    
            }
        }

        public int CreateAccount(AccountDto accountDto)
        {
            if(accountDto == null)
            {
                return 0;
            }

            accountDto.AcctId = accountDtos.Count + 1;

            accountDtos?.Add(accountDto);

            return accountDto.AcctId;
        }

        public AccountDto Load(int acctId)
        {
            return accountDtos?.FirstOrDefault(x => x.AcctId == acctId) ?? new AccountDto();
        }

        public async Task<IEnumerable<AccountDto>> LoadAll()
        {
            return await Task.FromResult(accountDtos.ToList());
        }

        public bool DeleteAccount(int acctId)
        {
            accountDtos?.RemoveAll(x => x.AcctId == acctId);

            return (!accountDtos?.Exists(x => x.AcctId == acctId)) ?? true;
        }

        //public bool UpdateAccount(int acctId)
        //{
        //    AccountDto accountDto = accountDtos?.FirstOrDefault(x => x.AcctId == acctId);


        //}
    }
}
