using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GmailBot.Utility
{
    public static class Extensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeout)
        {
            try
            {
                if(timeout > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                    wait.Until(ExpectedConditions.ElementExists(by));
                }
                return driver.FindElement(by);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static INavigation Navigate(this IWebDriver driver, int timeout = 0)
        {
            if(timeout > 0)
            {
                var time = timeout * 1000;
                Thread.Sleep(time);
            }
            return driver.Navigate();
        }

        public static IWebElement GetParent(IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }

        public  static IWebElement GetParentByLevel(IWebElement e, int level = 0)
        {
            try
            {
                IWebElement res = null;
                res = e;
                for (int i = 0; i < level; i++)
                    res = res.FindElement(By.XPath(".."));

                return res;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
