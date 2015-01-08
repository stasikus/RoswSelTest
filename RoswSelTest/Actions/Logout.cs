using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest.Actions
{
    public class Logout
    {
        public static void LogoutFromUser()
        {
            Driver.Instance.FindElementAndWait(By.XPath("//span[@class='links-more']//li[@class='dropdown']//div[2]/a")).Click();
        }
    }
}
