using TechTalk.SpecFlow;
using Selenium.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using log4net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Tests.Features
{
    [Binding]
    public class Steps
    {
        #region Properties
        private RegistrationPage register { get; set; }
        private string RegisteredUsername { get { return "johnsmithf10d51c2-92f9-47a7-9395-1661ca13e218"; } }
        private string RegisteredPassword { get { return "Test1234"; } }
        private string Directory { get; set; }
        private LoginPage login { get; set; }
        private HomePage home { get; set; }
        private Client Client { get; set; }
        private List<API> ActualResults { get; set; }
        private List<API> ExpectedResults { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private IWebDriver driver { get; set; }
        static protected ILog logger = LogManager.GetLogger("TestLog");
        #endregion

        #region Screenshot
        private void GetScreesnhot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] imageBytes = Convert.FromBase64String(screenshot.ToString());

            using (BinaryWriter bw = new BinaryWriter(new FileStream($"{Directory}\\Screenshot_{Guid.NewGuid()}.png", FileMode.Append, FileAccess.Write)))
            {
                bw.Write(imageBytes);
                bw.Close();
            }
        }
        #endregion

        #region Test Setup
        /// <summary>
        /// Create Chrome Driver Instance
        /// </summary>
        /// <returns>IWebDriver</returns>
        [Scope(Tag = "Selenium")]
        [BeforeScenario]
        public IWebDriver BeforeScenario()
        {
            Environment.SetEnvironmentVariable("chrome", "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe");
            Directory = AppDomain.CurrentDomain.BaseDirectory;
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArgument("--start-maximized");
            ChromeDriver _driver = new ChromeDriver(Directory, options);
            driver = _driver;
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }
        #endregion

        #region Test Cleanup
        /// <summary>
        /// Driver cleanup after each scenario
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                logger.Error(ScenarioContext.Current.ScenarioInfo.Title);
                logger.Error(ScenarioContext.Current.TestError.Message);
                logger.Error(ScenarioContext.Current.TestError.Source);
                logger.Error(ScenarioContext.Current.TestError.StackTrace);
                logger.Error(ScenarioContext.Current.StepContext);
            }
            logger.Debug($"{ScenarioContext.Current.ScenarioInfo.Title}, {ScenarioContext.Current.ScenarioExecutionStatus}");
            if (ScenarioContext.Current.ScenarioInfo.Tags.Equals("Login") || ScenarioContext.Current.ScenarioInfo.Tags.Equals("Registration"))
            {
                GetScreesnhot();
                driver.Quit();
            }
        }
        #endregion

        #region Given Bindings
        [Given(@"I navigate to the registration page")]
        public void GivenINavigateToRegistrationPage()
        {
            driver.Navigate().GoToUrl("https://www.nopcommerce.com/register.aspx");
            register = new RegistrationPage(driver);
            GetScreesnhot();
        }
        [Given(@"I navigate to the login page")]
        public void GivenINavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.nopcommerce.com/login.aspx");
            login = new LoginPage(driver);
            GetScreesnhot();
        }
        [Given(@"I enter my details")]
        public void GivenIEnterMyDetails()
        {
            register.FirstName.SendKeys("John");
            register.LastName.SendKeys("Smith");
            register.Email.SendKeys($"test{Guid.NewGuid()}@test.com");
            username = $"johnsmith{Guid.NewGuid()}";
            register.UserName.SendKeys(username);
            register.Select_Country.SelectByText("Australia");
            register.Select_Role.SelectByText("Technical / developer");
            password = "Test1234";
            register.Password.SendKeys("Test1234");
            register.ConfirmPassword.SendKeys("Test1234");
            GetScreesnhot();
        }
        [Given(@"I enter my login details")]
        public void GivenIEnterMyLoginDetails()
        {
            login.Username.SendKeys(RegisteredUsername);
            login.Password.SendKeys(RegisteredPassword);
            GetScreesnhot();
        }
        [Given(@"I request the public API")]
        public void GivenIFetchPublicAPI()
        {
            Client = new Client();
            ActualResults = Client.GetAPIRequest();
        }
        #endregion

        #region When Bindings
        [When(@"I press register button")]
        public void WhenIPressRegister()
        {
            GetScreesnhot();
            register.Register.Click();
            GetScreesnhot();
        }
        [When(@"I press login button")]
        public void WhenIPressLogin()
        {
            GetScreesnhot();
            login.Login.Click();
            GetScreesnhot();
        }
        [When(@"I compare the results")]
        public void WhenICompareAPIResults()
        {
            ExpectedResults = Client.GetAPIRequest();
        }
        #endregion

        #region Then Bindings
        [Then(@"my registration should be successful")]
        public void ThenRegistrationSuccess()
        {
            GetScreesnhot();
            Assert.IsTrue(register.RegistrationComplete.Displayed);
            GetScreesnhot();
        }
        [Then(@"I should be logged in")]
        public void ThenShouldBeLoggedIn()
        {
            home = new HomePage(driver);
            home.HomeLink.Click();
            home.MyAccount.Click();
            GetScreesnhot();
            Assert.IsTrue(DriverExtensions.FindElement(driver, By.XPath("//h1[text()='My account']"), 10).Displayed);
            GetScreesnhot();
        }
        [Then(@"they should be as expected")]
        public void ThenAPIResultsShouldBeAsExpected()
        {
            foreach (var pair in ActualResults.Zip(ExpectedResults, Tuple.Create))
            {
                Assert.AreEqual(pair.Item1.UserId, pair.Item2.UserId);
                Assert.AreEqual(pair.Item1.Id, pair.Item2.Id);
                Assert.AreEqual(pair.Item1.Title, pair.Item2.Title);
                Assert.AreEqual(pair.Item1.Body, pair.Item2.Body);
            }
        }
        #endregion
    }
}
