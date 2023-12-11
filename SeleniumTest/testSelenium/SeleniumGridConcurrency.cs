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

namespace SeleniumTest.testSeleniumGrid
{
    [TestFixture("chrome", "Windows 10")]
    [TestFixture("firefox ", "Windows 10")]
    [Parallelizable(ParallelScope.Fixtures)]
    //[TestFixture]
    public class SeleniumGrid
    {
        WebDriver driver;
        public static string uri = "http://192.168.1.5:4444";

        //ThreadLocal<IWebDriver> driver = new();
        private String browser;
        private String os;

        public SeleniumGrid(string browser, string os)
        {
            this.browser = browser;
            this.os = os;
        }

        [SetUp]
        public void Init()
        {
            //Console.WriteLine($"cersion >>>>>>> {version}");
            if (browser == "chrome")
            {
                ChromeOptions chromeOptions = new ChromeOptions();

                driver = new RemoteWebDriver(new Uri(uri), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(60));

            }
            else 
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions();

                driver = new RemoteWebDriver(new Uri(uri), firefoxOptions);
                Console.WriteLine(browser);


            }
        }

        [Test]
        public void Todotest()
        {

            Console.WriteLine("Navigating to todos app.");
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");

            driver.FindElement(By.Name("li4")).Click();
            Console.WriteLine("Clicking Checkbox");
            driver.FindElement(By.Name("li5")).Click();


            // If both clicks worked, then te following List should have length 2
            IList<IWebElement> elems = driver.FindElements(By.ClassName("done-true"));
            // so we'll assert that this is correct.
            Assert.AreEqual(2, elems.Count);

            Console.WriteLine("Entering Text");
            driver.FindElement(By.Id("sampletodotext")).SendKeys("Yey, Let's add it to list");
            driver.FindElement(By.Id("addbutton")).Click();


            // lets also assert that the new todo we added is in the list
            string spanText = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span")).Text;
            Assert.AreEqual("Yey, Let's add it to list", spanText);

        }

        [TearDown]
        public void Cleanup()
        {
            // Terminates the remote webdriver session
            driver.Quit();
        }

        //[Test]
        //public void SetUp()
        //{
        //    //new DriverManager().SetUpDriver(new ChromeConfig());

        //    //var chromeOptions = new ChromeOptions()
        //    //{
        //    //    PlatformName = "Windows 11",

        //    //};

        //    ChromeOptions chromeOptions = new();
        //    chromeOptions.PlatformName = "Windows 11";


        //    _driver = new RemoteWebDriver(new Uri("http://localhost:4444"), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
        //    try
        //    {
        //        _driver.Manage().Window.Maximize(); // WINDOWS, DO NOT WORK FOR LINUX/firefox. If Linux/firefox set window size, max 1920x1080, like driver.Manage().Window.Size = new Size(1920, 1080);
        //                                            // driver.Manage().Window.Size = new Size(1920, 1080); // LINUX/firefox			 
        //        _driver.Navigate().GoToUrl("https://www.google.com/ncr");
        //        IWebElement query = _driver.FindElement(By.Name("q"));
        //        query.SendKeys("webdriver");
        //        query.Submit();
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Video: SUccess");
        //        _driver.Quit();
        //    }
        //}

    }
}
