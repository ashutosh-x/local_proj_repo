using local_proj_repo.Base;
using local_proj_repo.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_proj_repo.Pages.Admin.UserManagement
{
    public class UsersPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "systemUserDiv")]
        public IWebElement mainTableNode { get; set; }

        public static string usersPageTitle = "Users";
        public void AssertUserIsRedirectedToUsersListPage()
        {
            WebDriverExtensions.WaitForElementToBePresent(Driver, By.XPath("//*[@id = 'systemUserDiv']//tr[2]"), 60);
            Assertions.AssertPageTitle(usersPageTitle);
        }
        public void ValidateTheHeaderValues()
        {
            IList<IWebElement> usersPageHeaderList = Driver.FindElements(By.XPath("//th"));
        }
    }
}
