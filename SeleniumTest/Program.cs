using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement ele = driver.FindElement(By.Name("q"));
            ele.SendKeys("javatpoint tutorials");
            
            IWebElement ele1 = driver.FindElement(By.Name("btnK"));
            //click on the search button  
            ele1.Click();
            driver.Close();



        }
    }
}
