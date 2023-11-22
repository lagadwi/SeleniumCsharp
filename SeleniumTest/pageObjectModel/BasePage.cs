using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    //public BasePage()
    //{
    //    InitializeDriver();
    //    ImplicitWait();
    //}

    public BasePage(IWebDriver driver)
    {
        
        this.driver = driver;

    }



    public void NavigateToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void CloseDriver()
    {
        driver.Quit();
    }
    public void ImplicitWait()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
    }

    public void ExplicitWait() {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

    }


}
