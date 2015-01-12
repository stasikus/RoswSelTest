using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoswSelTest
{
    public interface IWebDriverExt : IWebDriver
    {
        //Using default WebDriverWait timeout
        IWebElement FindElementAndWait(By by);
        //Can specify WebDriverWait timeout
        IWebElement FindElementAndWait(By by, int seconds);

        IWebElement IsElementPresent(By by);
    }

    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public FirefoxDriverExt() : base() { }
        public FirefoxDriverExt(FirefoxProfile profile) : base(profile) { }

        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
        {
            var element = DriverWait.Instance.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }

        public IWebElement IsElementPresent(By by)
        {
            try
            {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

            var element = DriverWait.Instance.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }
    }

}
