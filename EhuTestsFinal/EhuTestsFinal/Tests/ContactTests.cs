using NUnit.Framework;
using Shouldly;
using EhuTestsFinal.Pages;
using EhuTestsFinal.Utils;

namespace EhuTestsFinal.Tests
{
    public class ContactTests : BaseTest
    {
        [Test]
        public void ContactTest()
        {
            Logger.Info("Opening Contact page");

            var contact = new ContactPage(driver);

            contact.Open();
            var page = contact.GetContent();

            page.ShouldContain("gmail.com");
            page.ShouldContain("+370");
        }
    }
}