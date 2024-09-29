using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MantisAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public bool IsUserLogged(string username)
        {
            try
            {
                var userInfo = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[@class='user-info' and text()='{username}']")));
                return userInfo.Displayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Erro: O elemento 'user-info' não foi encontrado.");
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Erro: Tempo de espera excedido ao verificar o usuário logado.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar o usuário logado: {ex.Message}");
                return false;
            }
        }
    }
}