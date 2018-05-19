using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium.Library
{
    public static class DriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        public static void ScrollTo(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            var element = FindElement(driver, by, timeoutInSeconds);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
