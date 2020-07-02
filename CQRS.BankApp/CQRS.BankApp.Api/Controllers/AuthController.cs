using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginQuery login)
        {
            //Generate token command
            var token = new JWTModel();

            if(string.IsNullOrWhiteSpace(token.Token))
                return BadRequest();

            return Ok(token);
        }

        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    return Ok();
        //}
    }
}