using local_proj_repo.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_proj_repo.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetPageTitle()
        {
            return BaseClass.Driver.Title.Trim();
        }
        public static void MoveToElement(this IWebElement element)
        {
            Actions actions = new Actions(BaseClass.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public static void EnterText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
        public static string GetElementText(this IWebElement element, string value)
        {
            return element.Text;
        }
    }
}
