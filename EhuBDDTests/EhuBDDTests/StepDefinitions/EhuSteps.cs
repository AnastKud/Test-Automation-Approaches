using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using EhuTestsBDD.Drivers;

namespace EhuTestsBDD.StepDefinitions
{
    [Binding]
    public class EhuSteps
    {
        private readonly WebDriverManager _manager;
        private IWebDriver driver;

        public EhuSteps()
        {
            _manager = Hooks.GetDriver();
            driver = _manager.Driver;
        }

        [Given("user opens EHU homepage")]
        public void OpenHomepage()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");
        }

        [When("user clicks About link")]
        public void ClickAbout()
        {
            driver.FindElement(By.PartialLinkText("About")).Click();
        }

        [Then("About page should be opened")]
        public void CheckAboutPage()
        {
            Assert.That(driver.Url, Does.Contain("/about"));
            Assert.That(driver.Title, Does.Contain("About"));
        }

        [When(@"user searches for ""(.*)""")]
        public void Search(string text)
        {
            var js = (IJavaScriptExecutor)driver;

            IWebElement searchInput = (IWebElement)js.ExecuteScript(
                "return document.querySelector('input[name=\"s\"], input[type=\"search\"], .search-field');");

            js.ExecuteScript("arguments[0].value=arguments[1];", searchInput, text);

            IWebElement form = (IWebElement)js.ExecuteScript(
                "return arguments[0].closest('form');", searchInput);

            js.ExecuteScript("arguments[0].submit();", form);
        }

        [Then("search results page should be shown")]
        public void CheckSearch()
        {
            Assert.That(driver.Url, Does.Contain("s=study+programs"));
        }

        [When("user changes language to LT")]
        public void ChangeLanguage()
        {
            driver.FindElement(By.LinkText("EN")).Click();
            driver.FindElement(By.LinkText("LT")).Click();
        }

        [Then("Lithuanian site should be opened")]
        public void CheckLanguage()
        {
            Assert.That(driver.Url, Does.Contain("lt.ehuniversity.lt"));
        }

        [Given("user opens Contacts page")]
        public void OpenContacts()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
        }

        [Then("contact information should be visible")]
        public void CheckContacts()
        {
            var page = driver.PageSource;

            Assert.That(page, Does.Contain("franciskscarynacr@gmail.com"));
            Assert.That(page, Does.Contain("+370 68 771365"));
            Assert.That(page, Does.Contain("+375 29 5781488"));
        }
    }
}