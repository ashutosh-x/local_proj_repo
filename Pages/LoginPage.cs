using local_proj_repo.Base;
using local_proj_repo.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace local_proj_repo.Pages
{
    public class LoginPage : PageFactoryInit
    {

        [FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement txtUsername { get; set; }
        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement txtPassword { get; set; }
        public void LoginToHRMGateway(string UserType)
        {
            txtPassword.SendKeys("hello");
            txtUsername.SendKeys("hello");
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
