
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class LoginTest
{
    private IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    }

    [Test]
    public void FailedLoginTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.NavigateToUrl("https://practicetestautomation.com/practice-test-login/");
        loginPage.EnterUsername("invalid");
        loginPage.EnterPassword("invalid");
        loginPage.ClickLogin();
        Assert.AreEqual(("Your username is invalid!"), loginPage.ErrorMessage());
    }

    [Test]
    public void SuccedLoginTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.NavigateToUrl("https://practicetestautomation.com/practice-test-login/");

        loginPage.EnterUsername("student");
        loginPage.EnterPassword("Password123");
        loginPage.ClickLogin();
        Assert.IsTrue(loginPage.isSuccedLogin());
    }

    [Test]
    public void LogoutTest()
    {
        LoginPage loginPage = new LoginPage(driver);
        DashboardPage dashboardPage = new DashboardPage(driver);
        loginPage.NavigateToUrl("https://practicetestautomation.com/practice-test-login/");
        loginPage.EnterUsername("student");
        loginPage.EnterPassword("Password123");
        loginPage.ClickLogin();
        dashboardPage.ClickLogout();
        Assert.IsTrue(dashboardPage.isSuccedLogout());
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
