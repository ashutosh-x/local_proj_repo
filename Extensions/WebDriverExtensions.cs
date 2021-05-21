using local_proj_repo.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace local_proj_repo.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForSeconds(int timeInSeconds)
        {
            Thread.Sleep(timeInSeconds * 1000);
        }
        public static void WaitForElementToBeVisible(IWebElement locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(BaseClass.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
        }
        public static void WaitForElementToBePresent(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(BaseClass.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
        }
        public static void WaitForElementToLoad(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(BaseClass.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
        }
        public static void WaitForPageToLoad(this IWebDriver driver, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(BaseClass.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.ExecuteJs("return document.readyState").Equals("complete"));
        }
        public static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)BaseClass.Driver).ExecuteScript(script);
        }
    }
}
