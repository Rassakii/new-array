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
using System.Collections;

namespace seleniumlearning
{
    internal class sorttable
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
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");
            // step1 get all fruit name in arraylist
           IList<IWebElement> veggies=driver.FindElements(By.XPath("//tr//td[1]"));
            foreach(IWebElement veggie in veggies) 
            {
                a.Add(veggie.Text);
            
            }
            // step 2 sort the array list
            foreach (string element in a)
            {
                TestContext.Progress.WriteLine(element);

            }

            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);

            }

            // click the column
            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();
            // get them back in array list
            ArrayList b= new ArrayList();
            IList<IWebElement> sortedveggies = driver.FindElements(By.XPath("//tr//td[1]"));
            foreach (IWebElement veggie in sortedveggies)
            {
                b.Add(veggie.Text);

            }
            // arraylisrt a and arraylist b should be equal
            Assert.AreEqual(a,b);

        }

    }
}
