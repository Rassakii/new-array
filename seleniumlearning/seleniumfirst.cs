using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;


namespace seleniumlearning
{
    internal class Seleniumfirst
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //Method- get url
            //chromedriver.exe on chrome
            //geckodriver firefox
            //99.exe (99)
            //edgedriver.exe
             new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new FirefoxDriver();
           // driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            // Further test steps can be added here
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            //TestContext.Progress.WriteLine(driver.PageSource);
            //driver.Close(); 



        }
    }
}