using OpenQA.Selenium;

namespace EhuTestsFinal.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Search(string text)
        {
            var js = (IJavaScriptExecutor)driver;

            IWebElement input = (IWebElement)js.ExecuteScript(
                "return document.querySelector('input[name=\"s\"]');");

            js.ExecuteScript("arguments[0].value=arguments[1];", input, text);

            IWebElement form = (IWebElement)js.ExecuteScript(
                "return arguments[0].closest('form');", input);

            js.ExecuteScript("arguments[0].submit();", form);
        }
    }
}