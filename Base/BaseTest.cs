using Allure.Net.Commons;
using Allure.NUnit;
using DemoNUnitProject.Drivers;
using DemoNUnitProject.Utils;
using NUnit.Framework;
using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
// BaseTest.cs = Test lifecycle management ==>Each class has one clear responsibility.
namespace DemoNUnitProject.Base
{
    public class BaseTest
    {
        // protected IWebDriver driver;
        private static ThreadLocal<IWebDriver> ldriver = new ThreadLocal<IWebDriver>();
        protected IWebDriver Driver => ldriver.Value ?? throw new Exception("Driver not initialized");

        [SetUp]
        public void Setup()
        {
            string browser = ConfigReader.GetBrowser();
            //   string browser = "chrome"; // later from config
            ldriver.Value = DriverFactory.getDriver(browser); //“In parallel execution, we never use the ThreadLocal variable directly. We expose it through a read-only property and always interact with WebDriver via that property.”
            Driver.Manage().Window.Maximize();
        }

        [TearDown] // ✅ per test cleanup
        public void TearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var filePath = $"screenshot_{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(filePath);

                try
                {
                    // Attach screenshot to Allure if available. If Allure isn't active this may throw; swallow to avoid failing the test run.
                    AllureApi.AddAttachment(
                        "Screenshot",
                        "image/png",
                        filePath
                    );
                }
                catch
                {
                    // ignore
                }
            }

            if (ldriver.Value != null)
            {
                ldriver.Value.Quit();
                ldriver.Value.Dispose();
                ldriver.Value = null;
            }
        }

        [OneTimeTearDown] // ✅ only for ThreadLocal
        public void GlobalCleanup()
        {
            ldriver.Dispose();
        }
    }
}