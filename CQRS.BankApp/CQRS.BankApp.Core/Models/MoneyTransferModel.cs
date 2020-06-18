using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Core.Models
{
    public class MoneyTransferModel
    {
        public int ReceiverAccountId { get; set; }
        public int SenderAccountId { get; set; }

        public decimal Ammount { get; set; }
    }
}
