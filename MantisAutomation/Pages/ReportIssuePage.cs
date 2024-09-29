using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class ReportIssuePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ReportIssuePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement ReportIssueMenu => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()=' Report Issue ']")));
        private IWebElement CategoryDropdown => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category_id")));
        private IWebElement SummaryField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("summary")));
        private IWebElement DescriptionField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("description")));
        private IWebElement SubmitButton => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Submit Issue']")));

        public void ClickReportIssueMenu()
        {
            ReportIssueMenu.Click();
        }

        public void SelectCategory(string category)
        {
            var selectElement = new SelectElement(CategoryDropdown);
            selectElement.SelectByText(category);
        }

        public void EnterSummary(string summary)
        {
            SummaryField.SendKeys(summary);
        }

        public void EnterDescription(string description)
        {
            DescriptionField.SendKeys(description);
        }

        public void SubmitIssue()
        {
            SubmitButton.Click();
        }
    }
}