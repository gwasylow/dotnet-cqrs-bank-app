using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Consts.UserRole)]
    public class UserController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public UserController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }
        [HttpPost("GetUserDetails")]
        public IActionResult GetUserDetails([FromBody] GetUserDetailsQuery user)
        {
            return Ok(_queryBus.Send<GetUserDetailsQuery,UserDetailsModel>(user));
        }
    }
}