using CQRS.BankApp.Core.Models;
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
        private LoginModel _login;

        [TestInitialize]
        public void Init()
        {
            _JWTTokenService = new JWTTokenService();
            _login = new LoginModel
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
