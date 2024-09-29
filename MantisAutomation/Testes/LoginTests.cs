using NUnit.Framework;
using MantisAutomation.Drivers;
using MantisAutomation.Pages;
using OpenQA.Selenium;

namespace MantisAutomation.Tests
{
    public class LoginTests
    {
        private IWebDriver? _driver;
        private Driver _driverHelper;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driverHelper = new Driver();
            _driver = _driverHelper.StartDriver();
            
            _driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");
            
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void TestLoginWithValidCredentials()
        {
            _loginPage.Login("Jarbas_Batista", "Maju123!");

            var homePage = new HomePage(_driver);
            bool isLogged = homePage.IsUserLogged("Jarbas_Batista");

            Assert.IsTrue(isLogged, "Erro: O login não foi realizado corretamente. O usuário 'Jarbas_Batista' não foi encontrado na tela.");
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}