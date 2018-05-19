using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Library
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver) { }
        public IWebElement FirstName { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_txtFirstName"), 10); } }
        public IWebElement LastName { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_txtLastName"), 10); } }
        public IWebElement Email { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_Email"), 10); } }
        public IWebElement UserName { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_UserName"), 10); } }
        public IWebElement Country { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ddlCountry"), 10); } }
        public SelectElement Select_Country { get { return new SelectElement(Country); } }
        public IWebElement Role { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ddlRole"), 10); } }
        public SelectElement Select_Role { get { return new SelectElement(Role); } }
        public IWebElement Password
        {
            get
            {
                DriverExtensions.ScrollTo(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_Password"), 10);
                return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_Password"), 10);
            }
        }
        public IWebElement ConfirmPassword
        {
            get
            {
                DriverExtensions.ScrollTo(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ConfirmPassword"), 10);
                return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ConfirmPassword"), 10);
            }
        }
        public IWebElement Register
        {
            get
            {
                DriverExtensions.ScrollTo(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm___CustomNav0_StepNextButton"), 10);
                return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm___CustomNav0_StepNextButton"), 10);
            }
        }
        public IWebElement RegistrationComplete { get { return DriverExtensions.FindElement(_driver, By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CompleteStepContainer_lblCompleteStep"), 10); } }
    }
}