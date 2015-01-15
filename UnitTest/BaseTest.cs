using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoswSelTest;
using RoswSelTest.Actions;
using NUnit.Framework;

namespace UnitTest
{
    public  class BaseTest
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            Driver.Initialize();
            DriverWait.Initialize(2);
            //Driver.BrowserMaximize();
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            Driver.Wait(3);
            //Driver.Close();
        }
    }
}
