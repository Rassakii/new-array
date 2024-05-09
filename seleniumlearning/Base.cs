using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace c__selenium_framework.utilities
{
    public class Base
    {
        //Xpath,css,id,classname,name,tagname,linkname
         public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            String browsername = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browsername);
            //implicit wait declared globally  5 secs
            // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        public IWebDriver getdriver()
        {
            return driver;
        }
        public void InitBrowser(string browsername) 
        { 
            switch(browsername)
            {
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;



            }
        
        }
       [TearDown]
        public void StopBrowser() 
        {
           driver.Quit(); 
        }
    }
}
