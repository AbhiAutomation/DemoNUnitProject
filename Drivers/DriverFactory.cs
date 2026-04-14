using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
//DriverFactory.cs = Browser creation logic
namespace DemoNUnitProject.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver getDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless=new");
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-dev-shm-usage");
                    options.AddArgument("--disable-gpu");
                    options.AddArgument("--remote-debugging-port=9222");
                    options.BinaryLocation = "/usr/bin/google-chrome";

                    return new ChromeDriver(options);

                case "edge":
                    return new EdgeDriver();

                default:
                    throw new ArgumentException("Browser not supported");
            }
        }
    }
}