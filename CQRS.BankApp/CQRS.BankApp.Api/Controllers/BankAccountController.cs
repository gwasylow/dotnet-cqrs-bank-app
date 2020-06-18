using CQRS.BankApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        [HttpGet("id")]
        public IActionResult GetAccountsForUser(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult TransferMoney([FromBody] MoneyTransferModel moneyTransfer)
        {
            //
            return Ok();
        }
    }
}