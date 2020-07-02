using CQRS.BankApp.Core.Domains.UserDomain.Queries;
using CQRS.BankApp.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Tests.Core
{
    [TestClass]
    public class JWTTokenServiceTest
    {
        private JWTTokenService _JWTTokenService;
        private LoginQuery _login;

        [TestInitialize]
        public void Init()
        {
            _JWTTokenService = new JWTTokenService();
            _login = new LoginQuery
            {
                Login = "grazynka",
                Password = "grazynka"
            };
        }

        [TestMethod]
        public void ReturnNonEmptyTokenForUser()
        {
            var token = _JWTTokenService.GenerateJWT(_login);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(token));
        }


    }
}
