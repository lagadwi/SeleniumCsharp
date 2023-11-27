using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

[TestFixture]
public class IframeInteractions
{
    [Test]
    public void IframeWebElement()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demo.guru99.com/test/guru99home/");
        IWebElement iframe = driver.FindElement(By.Id("a077aa5e"));

        driver.SwitchTo().Frame(iframe);
        driver.FindElement(By.XPath("html/body/a/img")).Click();
        driver.SwitchTo().DefaultContent();
        driver.Quit();
    }

    [Test]
    public void IframeUsingId()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demo.guru99.com/test/guru99home/");

        driver.SwitchTo().Frame("a077aa5e");
        driver.FindElement(By.XPath("html/body/a/img")).Click();
        driver.SwitchTo().DefaultContent();
        driver.Quit();
    }

    [Test]
    public void IframeUsingIndex()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demo.guru99.com/test/guru99home/");
        ReadOnlyCollection<IWebElement> iframes = driver.FindElements(By.TagName("iframe"));
        Console.WriteLine(iframes.Count);
        for (int i = 0; i < iframes.Count-1; i++)
        {
            driver.SwitchTo().Frame(i);
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("html/body/a/img"));

            // Get the total count of matching elements
            int total = elements.Count;
            if(total > 0)
            {
                driver.FindElement(By.XPath("html/body/a/img")).Click();
            }

            driver.SwitchTo().DefaultContent();
        }

           
        driver.Quit();
    }
}