using CQRS.BankApp.Persistance.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Persistance
{
    public class MockDataContext : IDisposable
    {
        public IEnumerable<TblLogins> Logins { set; get; }
        public IEnumerable<TblBankAccounts> BankAccounts { set; get; }
        public IEnumerable<TblNotifications> Notifications { set; get; }

        public MockDataContext()
        {
            //Mock data
            MockData();
        }

        private void MockData()
        {
            Logins = new List<TblLogins>
            {
                new TblLogins
                {
                    Id= 1,
                    BankAccounts = null,
                    Login = "grazynka".ToUpper()
                },
                new TblLogins
                {
                    Id= 2,
                    BankAccounts = null,
                    Login = "janusz".ToUpper()
                }
            };

            BankAccounts = new List<TblBankAccounts>
            {
                new TblBankAccounts
                {
                    Id = 1,
                    AccountNo = "PL 0000 1234 2222 4444 01",
                    Balance = 500,
                    Login = Logins.FirstOrDefault(x=>x.Login == "grazynka".ToUpper())
                },
                new TblBankAccounts
                {
                    Id = 2,
                    AccountNo = "PL 0000 1234 2222 4444 02",
                    Balance = 655,
                    Login = Logins.FirstOrDefault(x=>x.Login == "grazynka".ToUpper())
                },
                new TblBankAccounts
                {
                    Id = 3,
                    AccountNo = "PL 0000 1111 2222 4444 03",
                    Balance = 1000,
                    Login = Logins.FirstOrDefault(x=>x.Login == "janusz".ToUpper())
                }
            };
            Notifications = new List<TblNotifications>();
        }

        public void Dispose()
        {
        }
    }
}
