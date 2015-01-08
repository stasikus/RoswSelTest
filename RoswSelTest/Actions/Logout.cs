using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest.Actions
{
    public class Logout
    {
        public static void LogoutFromUser()
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.SwitchTo().Frame("game-frame");
            
            var stackTrace = new StackTrace();

            Driver.Instance.FindElementAndWait(By.XPath("//div[@id='main']/div[1]/div//span[@class='links-more']")).Click();
            Driver.Instance.FindElementAndWait(By.XPath("//span[@class='links-more']//li[@class='dropdown']//div[2]/a")).Click();
        }
    }
}
