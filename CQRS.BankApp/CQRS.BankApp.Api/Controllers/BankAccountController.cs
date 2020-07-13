using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.AccountDomain.Commands;
using CQRS.BankApp.Core.Domains.AccountDomain.Queries;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly ICommandsBus _commandBus;
        private readonly IQueryBus _queryBus;

        public BankAccountController(ICommandsBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost("GetAccountsForUser/{userId}")]
        [Authorize(Roles = Consts.UserRole)]
        public IActionResult GetAccountsForUser(int userId)
        {
            var accounts = _queryBus.Send<GetAccountForUserIdQuery, IEnumerable<BankAccountModel>>(
                new GetAccountForUserIdQuery
                {
                    UserId = userId
                });

            return Ok(accounts);
        }

        [HttpPost("TransferMoney")]
        public IActionResult TransferMoney(MoneyTransferCommand moneyTransfer)
        {
            _commandBus.Send(moneyTransfer);
            return Ok();
        }
    }
}