using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace SeleniumTest.GettingStarted
{
    [TestFixture]
    public class UsingSeleniumTest
    {

        [Test]
        public void EightComponents()
        {
            ReportHelper.InitializeReport();
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            ReportHelper.StartTest("Verify Website Title");
            var title = driver.Title;
            Assert.AreEqual("Web form", title);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var textBox = driver.FindElement(By.Name("my-text"));
            var submitButton = driver.FindElement(By.TagName("button"));

            textBox.SendKeys("Selenium");
            submitButton.Click();

            var message = driver.FindElement(By.Id("message"));
            var value = message.Text;
            Assert.AreEqual("Received!", value);
            ReportHelper.LogTestResult(Status.Pass, "Title verified successfully.");

            driver.Quit();
            ReportHelper.FinalizeReport();

        }
    }
}
