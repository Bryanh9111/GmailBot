using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using GmailBot.Model;
using GmailBot.Service;
using GmailBot.Utility;

namespace GmailBot.AutomationProcess
{
    public class AutomationProcess
    {
        private DatabaseProvider _dbProvider;
        private By byObj;
        private IWebElement element;

        public AutomationProcess()
        {
            _dbProvider = new DatabaseProvider();
            byObj = null;
            element = null;
        }

        public void EmailSignUpAutomation()
        {
            try
            {
                //set up DI//
                var serviceProvider = new ServiceCollection()
                    .AddScoped<IWebAutomationSvc, WebAutomationSvc>(sp => new WebAutomationSvc())
                    .BuildServiceProvider();
                var _webAutomationSvc = serviceProvider.GetService<IWebAutomationSvc>();

                //step 1
                var navigation = _webAutomationSvc.Navigate(AppSetting.Url);

                //step2
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
