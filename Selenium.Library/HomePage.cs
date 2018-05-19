using OpenQA.Selenium;

namespace Selenium.Library
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }
        public IWebElement Login { get { return DriverExtensions.FindElement(_driver, By.Id(""), 10); } }
        public IWebElement MyAccount { get { return DriverExtensions.FindElement(_driver, By.XPath("//a[@class='account']"), 10); } }
    }
}
