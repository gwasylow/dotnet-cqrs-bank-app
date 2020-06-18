using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Core.Models
{
    public class JWTModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        
    }
}
