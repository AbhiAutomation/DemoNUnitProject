using NUnit.Framework;
using DemoNUnitProject.Base;
using DemoNUnitProject.Pages;
using Allure.NUnit;
using Allure.NUnit.Attributes;


// ✅ MUST be here (top level)
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]


namespace DemoNUnitProject.Tests
{

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Login Suite")]
    public class GoogleTest : BaseTest
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Abhishek")]
        [AllureDescription("Verify login page title")]
        public void VerifyGoogleTitle()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");

            GooglePage googlePage = new GooglePage(Driver);

            Assert.That(googlePage.getTitle(), Does.Contain("Google"));
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Abhishek")]
        [AllureDescription("Verify login page title1")]
        public void VerifyGoogleTitle1()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");

            GooglePage googlePage = new GooglePage(Driver);

            Assert.That(googlePage.getTitle(), Does.Contain("Abhishek"));
        }
    }
}