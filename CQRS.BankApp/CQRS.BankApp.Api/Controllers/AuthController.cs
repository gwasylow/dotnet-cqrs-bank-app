using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain.Commands;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandsBus _commandBus;

        public AuthController(IQueryBus queryBus, ICommandsBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginQuery login)
        {
            var token = _queryBus.Send<LoginQuery, JWTModel>(login);

            if (string.IsNullOrWhiteSpace(token.Token))
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("Logout")]
        public IActionResult Logout(UserLogoutCommand logout)
        {
            _commandBus.Send(logout);
            return Ok();
        }
    }
}