using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace RoswSelTest
{
    public class Driver
    {
        public static IWebDriverExt Instance { get; private set; }

        public static void Initialize()
        {
            FirefoxProfile properties = new FirefoxProfile();
            properties.SetPreference("profile", "default");
            Instance = new FirefoxDriverExt();
            //Setting Implicit Wait timeout
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
        }

        //Maximize Browser window
        public static void BrowserMaximize()
        {
            Instance.Manage().Window.Maximize();
        }

        //Close Driver
        public static void Close()
        {
            Instance.Dispose();
        }

        //Thread sleep
        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

    }

}
