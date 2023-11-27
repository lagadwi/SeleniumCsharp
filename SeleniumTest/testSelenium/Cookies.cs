using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

[TestFixture]

public class Cookies {

    [Test]
    public void GetCookies() {
        IWebDriver driver = new ChromeDriver();

        // Navigate to Url
        driver.Navigate().GoToUrl("https://example.com");
        driver.Manage().Cookies.AddCookie(new Cookie("foo", "bar"));

        // Get cookie details with named cookie 'foo'
        var cookie = driver.Manage().Cookies.GetCookieNamed("foo");
        System.Console.WriteLine("cookies  :" +cookie);
        driver.Quit();
    }

    [Test]
    public void GetAllCookies() {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");
        driver.Manage().Cookies.AddCookie(new Cookie("test1", "cookie1"));
        driver.Manage().Cookies.AddCookie(new Cookie("test2", "cookie2"));

        // Get All available cookies
        var cookies = driver.Manage().Cookies.AllCookies;
        System.Console.WriteLine("cookies  :" + cookies);
        driver.Quit();

    }

    [Test]
    public void DeleteCookie()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://example.com");
        driver.Manage().Cookies.AddCookie(new Cookie("test1", "cookie1"));
        var cookie = new Cookie("test2", "cookie2");
        driver.Manage().Cookies.AddCookie(cookie);
        var cookies = driver.Manage().Cookies.AllCookies;

        System.Console.WriteLine("cookies  :" + cookies);

        // delete a cookie with name 'test1'	
        driver.Manage().Cookies.DeleteCookieNamed("test1");

        // Selenium .net bindings also provides a way to delete
        // cookie by passing cookie object of current browsing context
        driver.Manage().Cookies.DeleteCookie(cookie);

        // Get All available cookies
        System.Console.WriteLine("cookies deleted  :" + cookies);
        driver.Quit();


    }
}

