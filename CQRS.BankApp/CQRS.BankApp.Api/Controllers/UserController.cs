using CQRS.BankApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.BankApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetUser([FromBody] UserModel user)
        {
            return Ok();
        }
    }
}