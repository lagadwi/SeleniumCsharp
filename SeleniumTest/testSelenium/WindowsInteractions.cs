using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

[TestFixture]
public class WindowsInteractions
{

    [Test]
    public void SwitchWindow()
    {
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        driver.Manage().Window.Maximize();

        driver.Navigate().GoToUrl("file:///C:/Users/laga_dp181/Downloads/text2.html");
        string originalWindow = driver.CurrentWindowHandle;
        Assert.AreEqual(driver.WindowHandles.Count, 1);
        driver.FindElement(By.LinkText("Visit Example.com")).Click();

        //IWebElement linkEle = driver.FindElement(By.XPath("(//div[@class='td-content']//p)[3]"));
        //IWebElement link = wait.Until(wd => wd.FindElement(By.LinkText("new window")).Displayed);
        //Actions actions = new Actions(driver);
        //actions.MoveToElement(link).Perform();
        //link.Click();

        wait.Until(wd => wd.WindowHandles.Count == 2);

        foreach (string window in driver.WindowHandles)
        {
            if (originalWindow != window)
            {
                driver.SwitchTo().Window(window);
                break;
            }
        }
        //Wait for the new tab to finish loading content
        wait.Until(wd => wd.Title == "Example Domain");
        driver.Close();

        //Switch back to the old tab or window
        driver.SwitchTo().Window(originalWindow);
        driver.Quit();
    }
    [Test]
    public void OpenTabAndWindow()
    {
        IWebDriver driver = new ChromeDriver();
        // Opens a new tab and switches to new tab
        // Opens a new tab and switches to new tab
        driver.SwitchTo().NewWindow(WindowType.Tab);

        // Opens a new window and switches to new window
         driver.SwitchTo().NewWindow(WindowType.Window);


    }
}