using local_proj_repo.Base;
using local_proj_repo.Pages;
using TechTalk.SpecFlow;

namespace local_proj_repo.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I have navigated to the portal")]
        public void GivenIHaveNavigatedToThePortal()
        {
            BaseClass.NavigateToSite();
        }
        [When(@"I login to the OrangHRM portal as (.*)")]
        public void WhenILoginToTheOrangHRMPortalAsUserType(string UserType)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginToHRMGateway(UserType);
        }
    }
}
