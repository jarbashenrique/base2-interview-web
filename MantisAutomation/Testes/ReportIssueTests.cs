using NUnit.Framework;
using MantisAutomation.Drivers;
using MantisAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Tests
{
    public class ReportIssueTests
    {
        private IWebDriver? _driver;
        private Driver _driverHelper;
        private LoginPage _loginPage;
        private ReportIssuePage _reportIssuePage;

        [SetUp]
        public void Setup()
        {
            _driverHelper = new Driver();
            _driver = _driverHelper.StartDriver();

            _driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");

            _loginPage = new LoginPage(_driver);
            _reportIssuePage = new ReportIssuePage(_driver);

            _loginPage.Login("Jarbas_Batista", "Maju123!");
        }

        [Test]
        public void TestReportIssue()
        {
            _reportIssuePage.ClickReportIssueMenu();
            _reportIssuePage.SelectCategory("[All Projects] categoria teste");
            string summaryText = "Teste de automação de issue";
            _reportIssuePage.EnterSummary(summaryText);

            _reportIssuePage.EnterDescription("Este é um teste de descrição de issue para a automação.");
            _reportIssuePage.SubmitIssue();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));

            var issueSummary = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[contains(@class, 'bug-summary') and contains(text(), '{summaryText}')]")));
            Assert.IsTrue(issueSummary != null, $"Erro: A issue não foi criada com o summary '{summaryText}'.");

            var issueStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(@class, 'bug-status') and contains(text(), 'new')]")));
            Assert.IsTrue(issueStatus != null, "Erro: O status da issue não está como 'new'.");
        }

        [Test]
        public void TestReportIssueWithoutSummary()
        {
            _reportIssuePage.ClickReportIssueMenu();
            _reportIssuePage.SelectCategory("[All Projects] categoria teste");
            _reportIssuePage.EnterDescription("Descrição de teste para um issue sem summary.");
            _reportIssuePage.SubmitIssue();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            bool issueCreated = false;

            try
            {
                var issueStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(@class, 'bug-status') and contains(text(), 'new')]")));
                issueCreated = issueStatus.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                issueCreated = false;
            }

            Assert.IsFalse(issueCreated, "Erro: A issue foi criada mesmo sem preencher o campo 'Summary'.");
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