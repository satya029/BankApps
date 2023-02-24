using Autofac;
using Bank.Application.CQRS.Interface;
using Bank.Application.IoC;
using Bank.Application.Models;
using Bank.Application.Users.Commands;
using Bank.Application.Users.Queries;
using Bank.Infrastructure;
using Bank.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Bank.Tests.Application
{
    [TestClass]
    public class AuthTests
    {
        private IContainer _container;
        private LoginQuery _loginModel;
        private LoginQuery _wrongLoginModel;

        [TestInitialize]
        public void Init()
        {
            //Initialize Autofac container instance
            var assembly = typeof(IDependentAssemblyMarker).Assembly;
            var builder = new ContainerBuilder();

            //Initialize all autofac modules in assembly
            builder.RegisterAssemblyModules(assembly);
            _container = builder.Build();

            //Init user login model
            _loginModel = new LoginQuery
            {
                Login = "satya".ToUpper(),
                Password = "demo"
            };

            _wrongLoginModel = new LoginQuery
            {
                Login = "satya".ToUpper(),
                Password = "demo"
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

        [TestMethod]
        public void RegisterUserToTheBlackList()
        {
            var token = _container.Resolve<IHandleQuery<LoginQuery, JWTModel>>().Handle(_loginModel);

            if (string.IsNullOrWhiteSpace(token.Token))
                Assert.Fail("User with correct credentials is not able to login");

            var userLogoutCommand = new UserLogoutCommand 
            { 
                Key = token.Token, 
                UserId = token.UserId 
            };

            _container.Resolve<IHandleCommand<UserLogoutCommand>>().Handle(userLogoutCommand);


            var isTokenBlacklisted = _container.Resolve<GenericRepository<TblInvalidKeys>>().GetAll().Where(x=>x.Key == token.Token).Any();

            Assert.IsTrue(isTokenBlacklisted);
        }

        [TestMethod]
        public void UserShouldGetUniqueTokenAfterLogin()
        {
            var tokenAfterFirstLogin = _container.Resolve<IHandleQuery<LoginQuery, JWTModel>>().Handle(_loginModel);
            var tokenAfterSecondLogin = _container.Resolve<IHandleQuery<LoginQuery, JWTModel>>().Handle(_loginModel);

            Assert.AreNotEqual(tokenAfterFirstLogin, tokenAfterSecondLogin);
        }
    }
}
