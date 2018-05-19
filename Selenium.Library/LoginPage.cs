using OpenQA.Selenium;

namespace Selenium.Library
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement Username { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_UserName"), 10); } }
        public IWebElement Password { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_Password"), 10); } }
        public IWebElement Login { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_LoginButton"), 10); } }
    }
}