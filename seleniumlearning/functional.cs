using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;

namespace seleniumlearning
{
    internal class functional
    {

        //Xpath,css,id,classname,name,tagname,linkname
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //implicit wait declared globally  5 secs
            // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }


        [Test]
        public void Dropdown()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            // to select by text
            //s.SelectByText("Teacher");
            // to select by value
            s.SelectByValue("consult");
            // to select by index
            //s.SelectByIndex(0);
            

            // to be sure of what to click just in case the app was updated
            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                    radioButton.Click();

            }

            Thread.Sleep(4000);
            driver.FindElement(By.Id("okayBtn")).Click();
            //Boolean result=driver.FindElement(By.Id("usertype")).Selected;
            //Assert.That(result, Is.True);   




        }
        



    }
}
