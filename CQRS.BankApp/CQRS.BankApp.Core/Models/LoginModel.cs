using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Models
{
    public  class LoginModel : IQuery
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
