using NUnit.Framework;
using Shouldly;
using EhuTestsFinal.Pages;
using EhuTestsFinal.Utils;

namespace EhuTestsFinal.Tests
{
    public class SearchTests : BaseTest
    {
        [Test]
        public void SearchTest()
        {
            Logger.Info("Running search test");

            var home = new HomePage(driver);
            var search = new SearchPage(driver);

            home.Open();
            search.Search("study programs");

            driver.Url.ShouldContain("study+programs");
        }
    }
}