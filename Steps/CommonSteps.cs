using local_proj_repo.Base;
using local_proj_repo.Extensions;
using local_proj_repo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace local_proj_repo.Steps
{
    [Binding]
    public class CommonSteps : TestInitializeHook
    {
        [BeforeScenario]
        public void OpenBrowser()
        {
            SetupApplication();
        }
        [Given(@"I have navigated to the portal")]
        public void GivenIHaveNavigatedToThePortal()
        {
            NavigateToSite();
            Assertions.AssertPageTitle("OrangeHRM");
        }
        [When(@"I click on Logout")]
        [Then(@"I click on Logout")]
        public void WhenIClickOnLogout()
        {
            CommonPage commonPage = new CommonPage();
            commonPage.ClickOnLogout();
        }

    }
}
