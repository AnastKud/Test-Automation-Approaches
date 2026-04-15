using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EhuTestsBDD.Drivers
{
    public class WebDriverManager
    {
        public IWebDriver Driver { get; private set; }

        public void Start()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Stop()
        {
            Driver.Quit();
        }
    }
}