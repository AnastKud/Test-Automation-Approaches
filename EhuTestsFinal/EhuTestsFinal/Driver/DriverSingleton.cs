using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace EhuTestsFinal.Driver
{
    public sealed class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}