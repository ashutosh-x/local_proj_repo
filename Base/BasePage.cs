using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_proj_repo.Base
{
    public class BasePage : BaseClass
    {
        public BasePage()
        {
            SeleniumExtras.PageObjects.PageFactory.InitElements(Driver, this);
        }
    }
}
