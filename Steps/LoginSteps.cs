using local_proj_repo.Base;
using local_proj_repo.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace local_proj_repo.Steps
{
    [Binding]
    public class LoginSteps : BasePage
    {
        [When(@"I login to the OrangHRM portal as (.*)")]
        public void WhenILoginToTheOrangHRMPortalAsUserType(string UserType)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginToHRMGateway(UserType);
        }
    }
}
