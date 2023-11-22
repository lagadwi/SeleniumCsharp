using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
public class DashboardPage : BasePage
{
    //private IWebElement Logout => WebDriverExtensions.FindElement(Driver, By.LinkText("Logout"), 10);
    private IWebElement ElementLogout => WebDriverExtensions.FindElement(driver, By.XPath("//div[contains(@class,'wp-block-button aligncenter')]"), 10);
    private IWebElement Logout => ElementLogout.FindElement(By.LinkText("Log out"));

    public DashboardPage(IWebDriver driver) : base(driver)
    {
     this.driver = driver;

    }

    public void ClickLogout()
    {
        Logout.Click();
    }

    public bool isSuccedLogout()
    {
        try
        {
            return driver.Url.Contains("practice-test-login");
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}

