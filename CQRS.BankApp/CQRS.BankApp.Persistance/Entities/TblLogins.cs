using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Persistance.Entities
{
    public class TblLogins : IMockEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password => "demo";
        public virtual List<TblBankAccounts> BankAccounts { get; set; }
        public virtual List<TblBankAccounts> PreDefinedAccounts { get; set; }
    }
}
