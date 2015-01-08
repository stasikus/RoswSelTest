using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoswSelTest;
using RoswSelTest.Actions;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Login()
        {
            Driver.Initialize();
            DriverWait.Initialize(5);
            Driver.BrowserMaximize();

            LoginAction.GoTo("http://roswar.ru");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\1\users.xml");

            string name = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("Name").FirstChild.Value;
            string email = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("email").FirstChild.Value;
            string pass = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("pass").FirstChild.Value;

            //XmlNodeList xmlList = xDoc.GetElementsByTagName("User");
            //string s = xmlList.Count.ToString();

            LoginAction.EnterCredentials(email, pass);

            string returnName = LoginAction.CheckName();

            if (returnName.Equals(name))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);

        }

        [TestMethod]
        public void Logout()
        {
            RoswSelTest.Actions.Logout.LogoutFromUser();
        }
    }
}
