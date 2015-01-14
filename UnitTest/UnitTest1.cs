using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoswSelTest;
using RoswSelTest.Actions;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using NUnit.Framework;


namespace UnitTest
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        //public void Initialize()
        //{
        //    Driver.Initialize();
        //    DriverWait.Initialize(5);
        //    Driver.BrowserMaximize();
        //}
        
        [Test]
        public void Login()
        {
            LoginAction.GoTo("http://roswar.ru");

            XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(@"F:\users.xml");
            //xDoc.Load(@"D:\1\users.xml");
            xDoc.Load(@"D:\1\test.xml");

            int userCounter = xDoc.DocumentElement.GetElementsByTagName("User").Count;

            for (int i = 0; i < userCounter; i++) //make the action for every user
            {
                string name = xDoc.DocumentElement.GetElementsByTagName("User").Item(i).SelectSingleNode("Name").FirstChild.Value;
                string email = xDoc.DocumentElement.GetElementsByTagName("User").Item(i).SelectSingleNode("email").FirstChild.Value;
                string pass = xDoc.DocumentElement.GetElementsByTagName("User").Item(i).SelectSingleNode("pass").FirstChild.Value;
                string max_level = xDoc.DocumentElement.GetElementsByTagName("User").Item(i).SelectSingleNode("max_level").FirstChild.Value;

                LoginAction.EnterCredentials(email, pass);

                string returnName = LoginAction.CheckName();

                if (returnName.Equals(name))
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
                else
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(false, "Failed on Login action");

                int countBandage = LoginAction.CheckBange();
                Actions.goToSquare(); //go to square

                Actions.enterToMetro(); //go to metro

                Driver.Wait(1);

                while (Convert.ToInt32(max_level) > Actions.metroLvl)
                {
                    bool attack;
                    bool skipTime;

                    Actions.checkHP(); //check HP and healing if it needs
                    Actions.ratsAttackBigButton(); //first big button for searching the rats

                    if (Actions.metroLvl % 5 == 0)
                        break;//attack = Actions.ratsAttackButton(); //attack the group of rats
                    else
                        attack = Actions.ratsAttackButton(); //attack the rat

                    if (!attack) //check if attack button are exis
                    {
                        skipTime = Actions.ratsTimeSkipButton(); //use bange for skip the timer

                        if (Actions.metroLvl % 5 == 0) //attack the rat after skiped timer
                            break;//attack = Actions.ratsAttackButton(); //attack the group of rats
                        else
                            attack = Actions.ratsAttackButton(); //attack the rat
                    }

                    Driver.Wait(2);
                    Actions.goToSquare(); //back to square

                    Driver.Wait(1);
                    Actions.enterToMetro(); //go to metro
                }

                Driver.Wait(1);
                Actions.goToSquare();
                RoswSelTest.Actions.Logout.LogoutFromUser();
            }
            //string metro = "";
        }

       // [Test]
        public void Logout()
        {
            RoswSelTest.Actions.Logout.LogoutFromUser();
        }
    }
}
