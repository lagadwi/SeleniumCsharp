using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


[TestFixture]

public class DragAndDrop
{

    [Test]
    public void DragAndDropTest()
    {
        IWebDriver driver = new ChromeDriver();

        // Navigate to Url
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dragAndDropTest.html");

        IWebElement item1 = driver.FindElement(By.Id("test1"));
        IWebElement item2 = driver.FindElement(By.Id("test2"));

        Actions actions = new Actions(driver);

        // Perform the drag-and-drop operation
        actions.DragAndDrop(item1, item2).Perform();
        driver.Quit();
    }
}
