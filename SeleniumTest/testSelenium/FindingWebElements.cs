using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Xml.Linq;

[TestFixture]
public class FindElementsExample
{
    [Test]
    public void GetElement()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");
        IList<IWebElement> elements = driver.FindElements(By.TagName("p"));
        foreach (IWebElement e in elements)
        {
            System.Console.WriteLine(e.Text);
        }
        driver.Quit();
    }

    [Test]
    public void FindElementsFromElement()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");

        // Get element with tag name 'div'
        IWebElement element = driver.FindElement(By.TagName("div"));

        // Get all the elements available with tag name 'p'
        IList<IWebElement> elements = element.FindElements(By.TagName("p"));
        foreach (IWebElement e in elements)
        {
            System.Console.WriteLine(e.Text);
        }
        driver.Quit();

    }

    [Test]
    public void ActiveElement()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.google.com");
        driver.FindElement(By.CssSelector("[name='q']")).SendKeys("webElement");

        // Get attribute of current active element
        string attr = driver.SwitchTo().ActiveElement().GetAttribute("title");
        System.Console.WriteLine(attr);

        //driver.Quit();

    }

}
