using OpenQA.Selenium;

namespace DemoNUnitProject.Pages
{
    public class GooglePage
    {
        protected IWebDriver Driver;

        public GooglePage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public string getTitle()
        {
            return Driver.Title;
        }
    }
}