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
            xDoc.Load(@"F:\users.xml");

            string name = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("Name").FirstChild.Value;
            string email = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("email").FirstChild.Value;
            string pass = xDoc.DocumentElement.GetElementsByTagName("User").Item(0).SelectSingleNode("pass").FirstChild.Value;
            
            LoginAction.EnterCredentials(email, pass);

            string returnName = LoginAction.CheckName();

            if (returnName.Equals(name))
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
            else
               Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(false);

        }

        [Test]
        public void Logout()
        {
            RoswSelTest.Actions.Logout.LogoutFromUser();
        }
    }
}
