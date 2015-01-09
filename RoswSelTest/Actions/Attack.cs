using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest.Actions
{
    public class Attack
    {
        public static bool enterToMetro
        {
            get
            {
                Driver.Instance.FindElement(By.XPath("//div[@class='header clear ']//a[@class='square']")).Click();

                Driver.Instance.FindElementAndWait(By.XPath("//div[@class='welcome']//a[5]//i")).Click();
                var metro = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='block-bordered metro-rats']//h3"));

                if (metro.Text == "Охота на крысомах")
                    return true;
                else
                    return false;
            }
        }

        public static void ratsAttack()
        {

        }
        
        
    }
}
