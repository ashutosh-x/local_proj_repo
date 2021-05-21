using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace local_proj_repo.Base
{
    public class TestInitializeHook : BaseClass
    {
        public static void NavigateToSite()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestPortal"]);
        }
        [AfterScenario]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
