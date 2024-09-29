using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement UsernameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
        private IWebElement PasswordField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            LoginButton.Click();

            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}