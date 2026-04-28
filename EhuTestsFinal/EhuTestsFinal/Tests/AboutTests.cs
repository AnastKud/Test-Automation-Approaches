using NUnit.Framework;
using Shouldly;
using EhuTestsFinal.Pages;
using EhuTestsFinal.Utils;

namespace EhuTestsFinal.Tests
{
    public class AboutTests : BaseTest
    {
        [Test]
        public void AboutPageTest()
        {
            var home = new HomePage(driver);

            Logger.Info("Opening homepage");
            home.Open();

            Logger.Info("Clicking About");
            home.ClickAbout();

            driver.Url.ShouldContain("/about");
            driver.Title.ShouldContain("About");
        }
    }
}