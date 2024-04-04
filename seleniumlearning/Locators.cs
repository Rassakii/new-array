using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;

namespace seleniumlearning
{
    internal class Locators
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
        public void LocatorsIdentification()
        {
            // Find the element once and reuse it
            driver.FindElement(By.Id("username")).SendKeys("Rasakii");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Rasakii");
            driver.FindElement(By.Name("password")).SendKeys("hjhsdhw");
            //css selector  and xpath
            // tagname(attribute=value)
            // handle checkbox
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            //click
            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            //Thread.Sleep(3000);
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            // explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.Id("signInBtn")), "Sign In"));
            //TestContext.Progress.WriteLine(errorMessage);
            // Find the web element with the link text "https://rahulshettyacademy.com/documents-request"
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            //Define the expected URL
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            //Get the value of the href attribute of the link element
            String hrefAttr = link.GetAttribute("href");
            //Assert that the expected URL matches the href attribute of the link
            Assert.AreEqual(expectedUrl, hrefAttr);
            // handle check box


            




            //link.Text()






        }

    }
}
