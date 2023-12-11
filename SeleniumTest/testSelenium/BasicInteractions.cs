using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]

public class BasicInterations
{

    [Test]
    public void Basic()
    {
       
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
       
        var title = driver.Title;
        Assert.AreEqual("Web form", title);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        //elements
        var textBox = driver.FindElement(By.Name("my-text"));
        var submitButton = driver.FindElement(By.TagName("button"));
        var textArea = driver.FindElement(By.XPath("//textarea[@class='form-control']"));
        textBox.SendKeys("Selenium");
        textArea.SendKeys("Selenium Text Area");

        //select option
        var selectElement = driver.FindElement(By.Name("my-select"));
        var select = new SelectElement(selectElement);
        IList<IWebElement> optionList = select.Options;
        IList<IWebElement> selectedOptionList = select.AllSelectedOptions;

        select.SelectByText("Two");
        select.SelectByValue("1");
        select.SelectByIndex(3);

        var checkbox2 = driver.FindElement(By.Id("my-check-2"));
        checkbox2.Click();

        submitButton.Click();

        var message = driver.FindElement(By.Id("message"));
        var value = message.Text;
        Assert.AreEqual("Received!", value);

        driver.Quit();

    }

}