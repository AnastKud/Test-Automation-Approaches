using OpenQA.Selenium;

namespace EhuTestsFinal.Pages
{
    public class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
        }

        public string GetContent()
        {
            return driver.PageSource;
        }
    }
}