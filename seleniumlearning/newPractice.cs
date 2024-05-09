using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Collections;

namespace seleniumlearning
{
    internal class newPractice
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
            driver.Url = "https://rahulshettyacademy.com/";
        }
        [Test]
        public void Fruitpage()
        {
            ArrayList a = new ArrayList();
            driver.FindElement(By.LinkText("Practice")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Olasupo");
            //driver.FindElement(By.Id("name")).SendKeys("Olasupo");
            driver.FindElement(By.Id("email")).SendKeys("Raskeemono75@gmail.com");
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
            driver.FindElement(By.Id("form-submit")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.CssSelector("a[href='https://rahulshettyacademy.com/seleniumPractise/#/']")).Click();
            IList<IWebElement> results = (IList<IWebElement>)driver.FindElements(By.XPath("//div[@class='products']']"));
            foreach (IWebElement result in results)
            {
                TestContext.Progress.WriteLine(result.FindElement(By.CssSelector("h4[class='product - name']")).Text);






            }
        }
    }
}
