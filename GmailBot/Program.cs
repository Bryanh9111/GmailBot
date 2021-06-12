using GmailBot.AutomationProcess;
using System.Diagnostics;

namespace GmailBot
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomationFlow automationFlow = new AutomationFlow();
            automationFlow.EmailSignUpAutomation();

            Process.GetCurrentProcess().Kill();
        }
    }
}
