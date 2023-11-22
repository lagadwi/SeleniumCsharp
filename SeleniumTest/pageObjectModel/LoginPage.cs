using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage:BasePage
{
    private readonly IWebDriver driver;

    private IWebElement UsernameField => driver.FindElement(By.Id("username"));

    //private IWebElement UsernameField => WebDriverExtensions.FindElement(Driver, By.Id("username"), 10);

    private IWebElement PasswordField => driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => driver.FindElement(By.Id("submit"));
    private IWebElement errorMessage => driver.FindElement(By.Id("error"));

    //private IWebElement errorMessage => WebDriverExtensions.FindElement(driver,By.Id("error"),10);

    public LoginPage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    // Page Elements






    // Page Methods
    public void EnterUsername(string username)
    {
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.SendKeys(password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }

    public bool IsFailedLoginMessageDisplayed()
    {
        try
        {
        
            return errorMessage.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public String ErrorMessage()
    {
        for (int i = 0; i<3; i++)
        {
            if (IsFailedLoginMessageDisplayed())
            {
                return errorMessage.Text;
            } else
            {
                Thread.Sleep(1000);
            }
        }
        return "element not found";


    }
    public bool isSuccedLogin()
    {
        try
        {
            return driver.Url.Contains("logged-in-successfully");
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}