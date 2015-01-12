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
                Driver.Instance.FindElementAndWait(By.XPath("//div[@class='welcome']//a[5]//i")).Click();
                var startPage = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='block-bordered metro-rats']//h3"));
                var inSearching = Driver.Instance.IsElementPresent(By.XPath("//div[@id='welcome-rat']//p[2]//button[2]//span//div"));

                if (startPage.Text == "Охота на крысомах" || inSearching.Text == "Мужественно убежать")
                    return true;
                else
                    return false;
            }
        }

        public static void GoToSquare()
        {
            Driver.Instance.FindElement(By.XPath("//div[@class='header clear ']//a[@class='square']")).Click();
        }

        public static void ratsAttackBigButton()
        {
            IWebElement firstButton = Driver.Instance.IsElementPresent(By.XPath("//div[@class='button-big button']")); //big button (first button)

            if (firstButton != null)
            {
                if (firstButton.Displayed == true)
                    firstButton.Click();
            }
        }

        public static bool ratsAttackButton()
        {
            IWebElement attackButton = Driver.Instance.IsElementPresent(By.XPath("//div[@id='welcome-rat']//p[2]//button[@onclick='metroFightRat();']")); //attack click (attack button)
            
            if (attackButton != null)
            {
                bool flag = attackButton.Displayed; //first state

                if (attackButton.Displayed == true)
                    attackButton.Click();

                return flag;
            }

            return false;
        }

        public static bool ratsTimeSkipButton()
        {
            IWebElement skipTimerButton = Driver.Instance.IsElementPresent(By.XPath("//div[@id='timer-rat-fight']//div[@onclick='elevatorToRatByHuntclubBadge()']")); //skip timer by bandge

            if (skipTimerButton != null)
            {
                bool flag = skipTimerButton.Displayed; //first state

                if (skipTimerButton.Displayed == true)
                    skipTimerButton.Click();

                return flag;
            }
            return false;
        }
        
        
    }
}
