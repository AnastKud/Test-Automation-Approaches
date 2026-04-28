using NUnit.Framework;
using Shouldly;
using EhuTestsFinal.Pages;
using EhuTestsFinal.Utils;

namespace EhuTestsFinal.Tests
{
    public class LanguageTests : BaseTest
    {
        [Test]
        public void LanguageTest()
        {
            Logger.Info("Changing site language");

            var home = new HomePage(driver);

            home.Open();
            home.ChangeLanguage();

            driver.Url.ShouldContain("lt.ehuniversity.lt");
        }
    }
}