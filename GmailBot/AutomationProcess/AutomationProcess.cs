using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using GmailBot.Model;
using GmailBot.Service;
using GmailBot.Utility;
using System.Threading;

namespace GmailBot.AutomationProcess
{
    public class AutomationProcess
    {
        private DatabaseProvider _dbProvider;
        private By byObj;
        private IWebElement element;
        private SelectElement select;

        public AutomationProcess()
        {
            _dbProvider = new DatabaseProvider();
            byObj = null;
            element = null;
            select = null;
        }

        public void EmailSignUpAutomation()
        {
            try
            {
                //set up DI
                var serviceProvider = new ServiceCollection()
                    .AddScoped<IWebAutomationSvc, WebAutomationSvc>(sp => new WebAutomationSvc())
                    .BuildServiceProvider();
                var _webAutomationSvc = serviceProvider.GetService<IWebAutomationSvc>();

                //step 1
                var navigation = _webAutomationSvc.Navigate(AppSetting.Url);

                //step2
                byObj = _webAutomationSvc.GetByObj("firstName", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "firsttest");

                //step3
                byObj = _webAutomationSvc.GetByObj("lastName", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "lasttest");

                //step4
                byObj = _webAutomationSvc.GetByObj("username", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "suibiantesttest3");

                //step5
                byObj = _webAutomationSvc.GetByObj(".//Input[@name = 'Passwd']", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "1qazxswedc!");

                //step6
                byObj = _webAutomationSvc.GetByObj(".//Input[@name = 'ConfirmPasswd']", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "1qazxswedc!");

                //step7
                byObj = _webAutomationSvc.GetByObj(".//button[contains(@class, 'VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b')]", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());

                //step8
                byObj = _webAutomationSvc.GetByObj("phoneNumberId", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "4807580632");

                //step9
                byObj = _webAutomationSvc.GetByObj(".//button[contains(@class, 'VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b')]", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());
                Thread.Sleep(20000);

                //need manual input

                //step10
                byObj = _webAutomationSvc.GetByObj(".//button[contains(@class, 'VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b')]", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());

                //step11
                byObj = _webAutomationSvc.GetByObj("day", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "16");

                //step12
                byObj = _webAutomationSvc.GetByObj("month", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                select = new SelectElement(element);
                select.SelectByValue("6");

                //step13
                byObj = _webAutomationSvc.GetByObj("year", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Input.ToDescriptionString(), "1991");

                //step14
                byObj = _webAutomationSvc.GetByObj("gender", ElementCategoryEnum.Id.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                select = new SelectElement(element);
                select.SelectByValue("2");

                //step15
                byObj = _webAutomationSvc.GetByObj(".//button[contains(@class, 'VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b')]", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());

                //step16
                byObj = _webAutomationSvc.GetByObj(".//div[@class = 'FliLIb kDmnNe']/div/button", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());

                //step17
                string script = "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";
                _webAutomationSvc.ExecuteJS(script);

                //step18
                byObj = _webAutomationSvc.GetByObj(".//button[contains(@class, 'VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b')]", ElementCategoryEnum.Xpath.ToDescriptionString());
                element = _webAutomationSvc.GetElement(byObj, 10, 1);
                element = _webAutomationSvc.PerformAction(element, TagCategoryEnum.Button.ToDescriptionString());
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
