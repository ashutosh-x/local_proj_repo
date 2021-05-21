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
    public class HomePageSteps : BasePage
    {
        [When(@"I should be redirected to the homepage of the OrangeHRM portal")]
        public void WhenIShouldBeRedirectedToTheHomepageOfTheOrangeHRMPortal()
        {
            Assertions.AssertPageTitle("Dashboard");
        }
        [When(@"I click on module ""(.*)""")]
        public void WhenIClickOnModule(string moduleName)
        {
            HomePage homePage = new HomePage();
            homePage.ClickOnModule(moduleName);
        }
        [When(@"I validate the main menu options displayed on the left side of the homepage")]
        public void IValidateTheMainMenuOptionsDisplayedOnTheLeftSideOfTheHomepage()
        {
            HomePage homePage = new HomePage();
            homePage.ValidateTheLeftPanelMenu();
        }

    }
}
