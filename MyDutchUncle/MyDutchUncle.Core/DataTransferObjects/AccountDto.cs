using MyDutchUncle.Core.Enums;
using System.Collections.Generic;

namespace MyDutchUncle.Core.DataTransferObjects
{
    public class AccountDto
    {
        public int AcctId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public Dictionary<SecurityQuestionCategories, string> SecurityQuestions { get; set; }

        public AccountDto()
        {
            SecurityQuestions = new Dictionary<SecurityQuestionCategories, string>();
        }
    }
}
