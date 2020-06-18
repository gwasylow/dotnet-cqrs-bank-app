using CQRS.BankApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            //Generate token command
            var token = new JWTModel();

            if(string.IsNullOrWhiteSpace(token.Token))
                return BadRequest();

            return Ok(token);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}