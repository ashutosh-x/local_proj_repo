using local_proj_repo.Base;
using local_proj_repo.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace local_proj_repo.Pages
{
    public class CommonPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "account-job")]
        public IWebElement userDropDown { get; set; }
        [FindsBy(How = How.Id, Using = "logoutLink")]
        public IWebElement logOutLink { get; set; }
        
        public void ClickOnLogout()
        {
            CollapseAllMenu();
            WebDriverExtensions.WaitForElementToBeVisible(userDropDown, 60);
            userDropDown.Click();
            WebDriverExtensions.WaitForElementToBeVisible(logOutLink, 60);
            logOutLink.Click();
        }
        public void CollapseAllMenu()
        {
            try
            {
                if (Driver.FindElement(
                    By.XPath("//*[@class = 'collapsible-body']//*[@class = 'collapsible-header waves-effect waves-orange active']")).Enabled)
                {
                    Driver.FindElement(
                        By.XPath("//*[@class = 'collapsible-body']//*[@class = 'collapsible-header waves-effect waves-orange active']")).Click();
                }

                if (Driver.FindElement(
                    By.XPath("//*[contains(@class, 'level1')]//*[@class = 'collapsible-header waves-effect waves-orange active']")).Enabled)
                {
                    Driver.FindElement(
                        By.XPath("//*[contains(@class, 'level1')]//*[@class = 'collapsible-header waves-effect waves-orange active']")).Click();
                }
            }
            catch (Exception e)
            {
                try
                {
                    if (Driver.FindElement(
                    By.XPath("//*[contains(@class, 'level1')]//*[@class = 'collapsible-header waves-effect waves-orange active']")).Enabled)
                    {
                        Driver.FindElement(
                            By.XPath("//*[contains(@class, 'level1')]//*[@class = 'collapsible-header waves-effect waves-orange active']")).Click();
                    }
                }
                catch (Exception i)
                {

                    Console.WriteLine(i.Message.ToString());
                }

                Console.WriteLine(e.Message.ToString());
            }
        }
            public string[] StringSplit(String[] seperator, IWebElement stringText)
        {
            return stringText.Text.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries);
        }
        public string[] StringSplit(String[] seperator, string stringText)
        {
            return stringText.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
