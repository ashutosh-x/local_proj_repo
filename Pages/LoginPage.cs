using local_proj_repo.Base;
using local_proj_repo.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace local_proj_repo.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement txtUsername { get; set; }
        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement txtPassword { get; set; }
        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement btnLogin { get; set; }
        public void LoginToHRMGateway(string UserType)
        {
            txtUsername.EnterText(UserType);
            txtPassword.EnterText("admin123");
            btnLogin.Click();
            WebDriverExtensions.WaitForPageToLoad(Driver, 60);
        }
    }
}
