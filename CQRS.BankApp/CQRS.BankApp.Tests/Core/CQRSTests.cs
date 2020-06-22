using Autofac;
using CQRS.BankApp.Core;
using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain;
using CQRS.BankApp.Core.Models;
using CQRS.BankApp.Persistance.Entities;
using CQRS.BankApp.Persistance.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CQRS.BankApp.Tests.Core
{
    [TestClass]
    public class CQRSTests
    {
        private IContainer _container;
        private LoginModel _loginModel;

        [TestInitialize]
        public void Init()
        {
            //Initialize Autofac container instance
            var assembly = typeof(ICoreAssemblyMarker).Assembly;
            var builder = new ContainerBuilder();

            //Initialize all autofac modules in assembly
            builder.RegisterAssemblyModules(assembly);
            _container = builder.Build();

            //Init user login model
            _loginModel = new LoginModel
            {
                Login = "grazynka".ToUpper(),
                Password = "demo"
            };
        }

        [TestMethod]
        public void QueryHandlerShouldBeAbleToAuthenticateUser()
        {
            var handler = _container.Resolve<IHandleQuery<LoginModel, JWTModel>>().Handle(_loginModel);
               Assert.IsTrue(!string.IsNullOrWhiteSpace(handler.Token) && handler.UserId>0);
        }



    }
}
