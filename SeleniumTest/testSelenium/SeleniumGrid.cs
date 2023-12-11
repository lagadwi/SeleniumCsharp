using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace SeleniumTest.testSelenium
{
    [TestFixture]
    [TestFixture]
    internal class SeleniumGrid
    {
        [Test]
        public void TestGrid()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            Uri GridUrl = new Uri ("http://192.168.1.5:4444");
            WebDriver driver = new RemoteWebDriver(GridUrl, chromeOptions);
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Quit();

        }
        [Test]
        public void TestGrid2()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            Uri GridUrl = new Uri("http://192.168.1.5:4444");
            WebDriver driver = new RemoteWebDriver(GridUrl, firefoxOptions);
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Quit();

        }
    }
    
}
