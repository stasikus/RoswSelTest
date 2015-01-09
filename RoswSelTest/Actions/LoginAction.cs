using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest
{
    public class LoginAction
    {
        public static void GoTo(string server)
        {
            Driver.Instance.Navigate().GoToUrl(server);
        }

        public static void EnterCredentials(string email, string password)
        {
            var loadForm = Driver.Instance.FindElementAndWait(By.XPath("//*[@class='auth']"), 1);
            if (loadForm != null)
            {
                var loginVal = Driver.Instance.FindElement(By.Id("email-input"));
                loginVal.Clear();
                loginVal.SendKeys(email);

                var passVal = Driver.Instance.FindElement(By.Id("pwd-input"));
                passVal.Clear();
                passVal.SendKeys(password);

                Driver.Instance.FindElement(By.XPath("//td[@class='td-login']/button")).Click();
            }
        }

        public static string CheckName()
        {
            string retName = null;

            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.SwitchTo().Frame("game-frame");

            retName = Driver.Instance.FindElementAndWait(By.XPath("//div[@id='content']/h3/span/a")).Text.ToString();
            
            return retName;
        }

        public static int CheckBange()
        {
            int retBandage;

            var retBandageVar = Driver.Instance.FindElementAndWait(By.XPath("//table[@class='inventary']//td[@class='equipment-cell']//dd[@htab='htabs']//div[@class='padding']//img[@src='/@/images/obj/badge.png']/../div[@class='count']")).Text.ToString();

            retBandage = Convert.ToInt32(retBandageVar.Remove(0,1));

            return retBandage;
        }
    }
}
