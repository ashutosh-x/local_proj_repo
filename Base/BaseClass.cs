using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace local_proj_repo.Base
{
    public class BaseClass
    {
        public static IWebDriver Driver { get; set; }

        public static void SetupApplication()
        {
            if (ConfigurationManager.AppSettings["Browser"] == "Chrome")
            {
                ChromeOptions Chromeoptions = new ChromeOptions();
                Chromeoptions.AddAdditionalCapability("useAutomationExtension", false);
                Chromeoptions.AddArgument("--start-maximized");
                Chromeoptions.AddArgument("--no-sandbox");
                Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), Chromeoptions);
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            else if (ConfigurationManager.AppSettings["Browser"] == "Firefox")
            {
                FirefoxOptions FirefoxOptions = new FirefoxOptions();
                FirefoxOptions.AddArgument("--start-maximized");
                Driver = new FirefoxDriver(FirefoxOptions);
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            else if (ConfigurationManager.AppSettings["Browser"] == "Edge")
            {
                Driver = new EdgeDriver();
                Driver.Manage().Cookies.DeleteAllCookies();
            }
        }
        public static void NavigateToSite()
        {
            SetupApplication();
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestPortal"]);
        }
        [AfterScenario]
        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
