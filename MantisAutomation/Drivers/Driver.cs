using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MantisAutomation.Drivers
{
    public class Driver
    {
        private IWebDriver? _driver;

        public IWebDriver StartDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");

            try
            {
                _driver = new ChromeDriver(chromeOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar o ChromeDriver: {ex.Message}");
                throw;
            }

            return _driver;
        }

        public void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}