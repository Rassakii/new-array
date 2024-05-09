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
using AngleSharp.Text;
using c__selenium_framework.utilities;


namespace c__selenium_framework.test
{
    public class checkamate : Base
    {


        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProduct = new string[2];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));
            //rdos[1].Click();   
            // to be sure of what to click just in case the app was updated
            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("admin"))
                    radioButton.Click();

            }
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByValue("consult");
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {

                string productTextLower = product.Text.Trim().ToLower();
                if (expectedProducts.Any(expectedProduct => productTextLower.Contains(expectedProduct.ToLower())))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }





            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> checkoutcards = driver.FindElements(By.CssSelector("h4 a"));
            for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualProduct[i] = checkoutcards[i].Text;



            }
            Assert.AreEqual(expectedProducts, actualProduct);
            driver.FindElement(By.CssSelector("button[class*='btn-success']")).Click();
            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            IWebElement checkbox = driver.FindElement(By.Id("checkbox2"));
            // Scroll the checkbox into view if necessary
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            // Click the checkbox using JavaScript
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string confrimtext = driver.FindElement(By.CssSelector(".alert-success")).Text;
            //StringAssert.Contains("success ! Thank you! Your order will be delivered in next few weeks :-).", confrimtext);


        }
    }
}
