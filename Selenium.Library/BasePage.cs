using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Library
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public IWebElement HomeLink { get { return DriverExtensions.FindElement(_driver, By.XPath("//a[@href='https://www.nopcommerce.com/']"), 10); } }
        public IWebElement Login { get { return DriverExtensions.FindElement(_driver, By.XPath("//ul[@class='header-links-account']//a[@href='/login.aspx']"), 10); } }
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            WaitForPageLoad();
        }
        protected virtual void WaitForPageLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            wait.Until(wd => (string)js.ExecuteScript("return document.readyState") == "complete");
        }
    }
}
