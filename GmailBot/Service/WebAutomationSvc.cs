using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GmailBot.Utility;
using GmailBot.Model;

namespace GmailBot.Service
{
    /// <summary>
    /// WebAutomationSvc
    /// </summary>
    public class WebAutomationSvc: IWebAutomationSvc
    {
        private IWebDriver _driver;
        private const int timeMultiplier = 1000, launcationTime = 120;
        /// <summary>
        /// Constructor
        /// </summary>
        public WebAutomationSvc()
        {
            var configs = new ChromeOptions();
            configs.AddUserProfilePreference("download.prompt_for_download", false);
            configs.AddUserProfilePreference("download.directory_upgrade", true);
            configs.AddUserProfilePreference("disable-popup-blocking", true);
            configs.AddArguments("disable-infobars");
            configs.AddArguments("--start-maximized");
            configs.AddArgument("no-sandbox");
            _driver = new ChromeDriver(AppSetting.DriverLocation, configs, TimeSpan.FromSeconds(launcationTime));
        }
        /// <summary>
        /// Navigate
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public INavigation Navigate(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            try
            {
                INavigation navigation = null;
                navigation = _driver.Navigate();
                navigation.GoToUrl(url);
                return navigation;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// GetByObj
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public By GetByObj(string searchParameter, string category)
        {
            if(string.IsNullOrEmpty(searchParameter))
                throw new ArgumentNullException(nameof(searchParameter));

            try
            {
                if (string.Equals(category, ElementCategoryEnum.Id.ToDescriptionString()))
                    return By.Id(searchParameter);
                else if (string.Equals(category, ElementCategoryEnum.Xpath.ToDescriptionString()))
                    return By.XPath(searchParameter);
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// GetElement
        /// </summary>
        /// <param name="by"></param>
        /// <param name="findTimeInSec"></param>
        /// <param name="sleepTimeInSec"></param>
        /// <param name="hasParent"></param>
        /// <param name="parentLvl"></param>
        /// <returns></returns>
        public IWebElement GetElement(By by, int findTimeInSec, int sleepTimeInSec, bool hasParent, int parentLvl)
        {
            if (by == null)
                throw new ArgumentNullException(nameof(by));

            try
            {
                IWebElement element = null;
                element = _driver.FindElement(by, findTimeInSec);
                if (hasParent && parentLvl > 0)
                    element = Extensions.GetParentByLevel(element, parentLvl);

                if (element != null)
                    Thread.Sleep(sleepTimeInSec * timeMultiplier);

                return element;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// PerformAction
        /// </summary>
        /// <param name="element"></param>
        /// <param name="tagCategory"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IWebElement PerformAction(IWebElement element, string tagCategory, string value)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            try
            {
                if (string.Equals(tagCategory, TagCategoryEnum.Input.ToDescriptionString()))
                    element.SendKeys(value);
                else if (string.Equals(tagCategory, TagCategoryEnum.Button.ToDescriptionString()))
                    element.Click();
                else
                    return null;

                return element;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// CloseWebDriver
        /// </summary>
        /// <param name="sleepTimeInSec"></param>
        /// <returns></returns>
        public bool CloseWebDriver(int sleepTimeInSec)
        {
            if (sleepTimeInSec < 0)
                throw new ArgumentOutOfRangeException("sleepTimeInSec should be positive");

            try
            {
                Thread.Sleep(sleepTimeInSec * timeMultiplier);
                _driver.Quit(); //Close()
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public bool KillChromeProcesses()
        {
            try
            {
                Process[] chromeInstances = Process.GetProcessesByName("chrome");

                foreach (Process p in chromeInstances)
                    p.Kill();

                Thread.Sleep(5000);
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
