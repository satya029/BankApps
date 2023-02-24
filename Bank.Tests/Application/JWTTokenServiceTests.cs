using Bank.Application.Services;
using Bank.Application.Users.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bank.Tests.Application
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
                Login = "satya",
                Password = "satya"
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
