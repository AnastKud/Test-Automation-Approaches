using OpenQA.Selenium;

namespace EhuTestsFinal.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");
        }

        public void ClickAbout()
        {
            driver.FindElement(By.PartialLinkText("About")).Click();
        }

        public void ChangeLanguage()
        {
            driver.FindElement(By.LinkText("EN")).Click();
            driver.FindElement(By.LinkText("LT")).Click();
        }
    }
}