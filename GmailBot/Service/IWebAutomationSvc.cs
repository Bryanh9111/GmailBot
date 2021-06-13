using System;
using OpenQA.Selenium;

namespace GmailBot.Service
{
    /// <summary>
    /// IWebAutomationSvc
    /// </summary>
    public interface IWebAutomationSvc
    {
        /// <summary>
        /// Navigate
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        INavigation Navigate(string url);
        /// <summary>
        /// GetByObj
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        By GetByObj(string searchParameter, string category = "");
        /// <summary>
        /// GetElement
        /// </summary>
        /// <param name="by"></param>
        /// <param name="findTimeInSec"></param>
        /// <param name="sleepTimeInSec"></param>
        /// <param name="hasParent"></param>
        /// <param name="parentLvl"></param>
        /// <returns></returns>
        IWebElement GetElement(By by, int findTimeInSec = 0, int sleepTimeInSec = 0, bool hasParent = false, int parentLvl = 0);
        /// <summary>
        /// PerformAction
        /// </summary>
        /// <param name="element"></param>
        /// <param name="tagCategory"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IWebElement PerformAction(IWebElement element, string tagCategory, string value = "");
        /// <summary>
        /// ExecuteJS
        /// </summary>
        /// <param name="js"></param>
        /// <returns></returns>
        bool ExecuteJS(string js);
        /// <summary>
        /// CloseWebDriver
        /// </summary>
        /// <param name="sleepTimeInSec"></param>
        /// <returns></returns>
        bool CloseWebDriver(int sleepTimeInSec = 0);
        /// <summary>
        /// KillChromeProcesses
        /// </summary>
        /// <returns></returns>
        bool KillChromeProcesses();
    }
}
