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
    internal class Allertactionautosuggestive
    {
        // testing if i can sort the poage
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
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void test_alert()
        {
            String name = "Olasupo Abdulrasaq";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick *= 'displayConfirm']")).Click();
            // to handle it you have to switchg your driver to allert
            string alerttext = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //driver.SwitchTo().Alert().Dismiss();
            StringAssert.Contains(name, alerttext);
           // driver.SwitchTo().Alert().SendKeys(" whatever you want");







        }
        [Test]
        public void auto_suggestivedropdown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("nig");
            Thread.Sleep(5000);
            IList <IWebElement> options=driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach(IWebElement option in options)
            {
                if(option.Text.Equals("Nigeria"))
                    option.Click();
            
            
            }
            // to get the text at run time you use get attribute 
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));


        }

        [Test]
        public void Dropdown_buton() 
        {
            IWebElement dropdown = driver.FindElement(By.Id("dropdown-class-example"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByValue("option2");
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[class='radioButton']"));
            //rdos[1].Click();
            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("radio3"))
                    radioButton.Click();

            }



        }
        [Test]
        public void Frame()
        {// scroll down to frame
         IWebElement framescroll = driver.FindElement(By.Id("courses-iframe"));
         // You cannot scroll directly in Selenium, so you use JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);
            // id,name
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            // you have to scroll down the page to use the frame

        
        
        }

    }
}
