using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__selenium_framework.page_object
{
    internal class Finalpage
    {
        private IWebDriver driver;

        public Finalpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebElement country()
        {
            return driver.FindElement(By.CssSelector("input[class*='validate filter']"));

        }
       
        public void Waitforcountrydisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }
        private IWebElement findcountry()
        {
            return driver.FindElement(By.LinkText("India"));

        }
        public void Insertcountry(string county)
        {

            country().SendKeys(county);
       
        }
        public void cliccountry()
        {
            findcountry().Click();
        }
        private IWebElement submit()
        {
            return driver.FindElement(By.CssSelector("input[type='submit']"));

        }
        public void submitorder()
        {
            submit().Click();
        }

    }
}
