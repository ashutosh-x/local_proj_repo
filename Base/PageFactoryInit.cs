using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_proj_repo.Base
{
    public class PageFactoryInit : BaseClass
    {
        public PageFactoryInit()
        {
            SeleniumExtras.PageObjects.PageFactory.InitElements(Driver, this);
        }
    }
}
