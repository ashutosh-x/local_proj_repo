using local_proj_repo.Base;
using local_proj_repo.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace local_proj_repo.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy (How = How.XPath, Using = "//*[@id = 'menu-content']")]
        public IWebElement nodeMenuContent { get; set; }

        public static string adminTxt = "Admin";
        public static string pimTxt = "PIM";
        public static string myInfoTxt = "My Info";
        public static string leaveTxt = "Leave";
        public static string timeTxt = "Time";
        public static string attendanceTxt = "Attendance";
        public static string recruitmentTxt = "Recruitment";
        public static string disciplineTxt = "Discipline";
        public static string trainingTxt = "Training";
        public static string performanceTxt = "Performance";
        public static string succesAndDevTxt = "Succession & Development";
        public static string onboardingTxt = "On-boarding";
        public static string expenseTxt = "Expense";
        public static string reportsTxt = "Reports Catalog";
        public static string moreTxt = "More";
        public static string maintenanceTxt = "Maintenance";
        public void ClickOnModule(string moduleName)
        {
            IWebElement moduleLink = Driver.FindElement(By.XPath("//*[text() = '" + moduleName + "']/../span[2]"));
            WebDriverExtensions.WaitForElementToBeVisible(moduleLink, 60);
            moduleLink.Click();
        }
        public void ValidateTheLeftPanelMenu()
        {
            IList<IWebElement> listOfMainMenuList = nodeMenuContent.FindElements(By.XPath("//li[contains(@class,'level1')]"));
            Assert.AreEqual(adminTxt, listOfMainMenuList[0].Text);
            Assert.AreEqual(pimTxt, listOfMainMenuList[1].Text);
            Assert.AreEqual(myInfoTxt, listOfMainMenuList[2].Text);
            Assert.AreEqual(leaveTxt, listOfMainMenuList[3].Text);
            Assert.AreEqual(timeTxt, listOfMainMenuList[4].Text);
            Assert.AreEqual(attendanceTxt, listOfMainMenuList[5].Text);
            Assert.AreEqual(recruitmentTxt, listOfMainMenuList[6].Text);
            Assert.AreEqual(disciplineTxt, listOfMainMenuList[7].Text);
            Assert.AreEqual(trainingTxt, listOfMainMenuList[8].Text);
            Assert.AreEqual(performanceTxt, listOfMainMenuList[9].Text);
            Assert.AreEqual(succesAndDevTxt, listOfMainMenuList[10].Text);
            Assert.AreEqual(onboardingTxt, listOfMainMenuList[11].Text);
            Assert.AreEqual(expenseTxt, listOfMainMenuList[12].Text);
            Assert.AreEqual(reportsTxt, listOfMainMenuList[13].Text);
            Assert.AreEqual(maintenanceTxt, listOfMainMenuList[15].Text);
        }
    }
}
