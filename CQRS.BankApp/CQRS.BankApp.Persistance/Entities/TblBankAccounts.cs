using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Persistance.Entities
{
    public class TblBankAccounts : IMockEntity
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public TblLogins Login { get; set; }
    }
}
