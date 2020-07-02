using Autofac;
using CQRS.BankApp.Core;
using CQRS.BankApp.Core.CQRS;
using CQRS.BankApp.Core.Domains.UserDomain;
using CQRS.BankApp.Core.Domains.UserDomain.Queries;
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
        private LoginQuery _loginModel;
        private LoginQuery _wrongLoginModel;

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
            _loginModel = new LoginQuery
            {
                Login = "grazynka".ToUpper(),
                Password = "demo"
            };

            _wrongLoginModel = new LoginQuery
            {
                Login = "grazynka".ToUpper(),
                Password = "demo1"
            };
        }

        [TestMethod]
        public void QueryHandlerShouldBeAbleToAuthenticateUser()
        {
            var handler = _container.Resolve<IHandleQuery<LoginQuery, JWTModel>>().Handle(_loginModel);
               Assert.IsTrue(!string.IsNullOrWhiteSpace(handler.Token) && handler.UserId>0);
        }
        [TestMethod]
        public void QueryHandlerShouldBeAbleToDetectNotAuthenticatedUser()
        {
            var handler = _container.Resolve<IHandleQuery<LoginQuery, JWTModel>>().Handle(_wrongLoginModel);
            Assert.IsTrue(string.IsNullOrWhiteSpace(handler.Token) || handler.UserId > 0);
        }



    }
}
