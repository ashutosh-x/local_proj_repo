using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_proj_repo.Extensions
{
    public static class Assertions
    {
        public static void AssertPageTitle(string expectedValue)
        {
            StringAssert.AreEqualIgnoringCase(expectedValue, WebElementExtensions.GetPageTitle());
        }
    }
}
