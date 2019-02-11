using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDutchUncle.Core.DataTransferObjects;
using MyDutchUncle.Transport.Abstractions.Handlers;

namespace MyDutchUncle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCreationController : ControllerBase
    {
        #region Privates
        private readonly IAccountCreationHandler _accountCreationHandler;
        #endregion

        #region Constructors
        public AccountCreationController(IAccountCreationHandler accountCreationHandler)
        {
            _accountCreationHandler = accountCreationHandler;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccts()
        {
            var logger = NLog.LogManager.GetLogger("local");
            IEnumerable<AccountDto> accountDtos = new List<AccountDto>();

            try
            {             
                accountDtos = await _accountCreationHandler.LoadAccounts();

                return Ok(accountDtos);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error occurred while loading accounts.");

                return Ok(accountDtos);
            }
        }

        // GET: api/AccountCreation/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccountCreation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AccountCreation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
