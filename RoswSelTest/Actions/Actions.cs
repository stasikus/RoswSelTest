using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest.Actions
{
    public class Actions
    {
        public static bool enterToMetro()
        {
            Driver.Instance.FindElementAndWait(By.XPath("//div[@class='welcome']//a[5]//i")).Click();
            var startPage = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='block-bordered metro-rats']//h3"));
            var inSearching = Driver.Instance.IsElementPresent(By.XPath("//div[@id='welcome-rat']//p[2]//button[2]//span//div"));

            if (startPage.Text == "Охота на крысомах" || inSearching.Text == "Мужественно убежать")
                return true;
            else
                return false;
        }

        public static int metroLvl
        {
            get
            {
                int metrolvl = -1;

                IWebElement timerLvl = Driver.Instance.IsElementPresent(By.XPath("//table[@class='process']//tr[1]//td[1]"));
                IWebElement waitLvl = Driver.Instance.IsElementPresent(By.XPath("//div[@class='holders']"));

                if (timerLvl != null || waitLvl != null)
                {
                    if (timerLvl.Text != "")
                    {
                        string s = timerLvl.Text.ToString();
                        string[] lvlm = s.Split(' ');
                        metrolvl = Convert.ToInt32(lvlm[2]);
                    }
                    else
                    {
                        string s = waitLvl.Text.ToString();
                        metrolvl = Convert.ToInt32(s.Remove(0, s.IndexOf(": ") + 2).Remove(2));
                    }
                }

                return metrolvl;
            }
        }

        public static void goToSquare()
        {
            Driver.Instance.FindElementAndWait(By.XPath("//div[@class='header clear ']//a[@class='square']")).Click();
        }

        public static void checkHP()
        {
            string currentHP = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='life']//span[@id='currenthp']")).Text.ToString(); // currenthp
            string maxhp = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='life']//span[@id='maxhp']")).Text.ToString(); // maxhp

            double diff = Convert.ToDouble(currentHP) * 100.0 / Convert.ToDouble(maxhp);

            if (diff < 75.0)
            {
                Driver.Instance.FindElementAndWait(By.XPath("//div[@class='life']//div[@class='bar']//i")).Click();
            }
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
