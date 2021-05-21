using local_proj_repo.Base;
using local_proj_repo.Pages;
using local_proj_repo.Pages.Admin.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace local_proj_repo.Steps.Admin.UserManagement
{
    [Binding]
    public class UsersSteps : BasePage
    {
        [Then(@"I assert that the user is redirected to the users list page")]
        public void IAssertThatTheUserIsRedirectedToTheUsersListPage()
        {
            UsersPage users = new UsersPage();
            users.AssertUserIsRedirectedToUsersListPage();
        }
    }
}
