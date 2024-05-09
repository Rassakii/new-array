using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__selenium_framework.page_object
{
    internal class Loginpage
    {
        private IWebDriver driver;

        public Loginpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Define the username field using FindsBy attribute
        // defone password
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;
        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signin;

        public productpage Validlogin(string User,string pass)
        {
            username.SendKeys(User);
            password.SendKeys(pass);
            checkbox.Click();
            signin.Click();
            /// creeate obejct for the product page
            return new productpage(driver);
        
        }


        // Getter method to access the username field
        public IWebElement GetUsername()
        {
            return username;
        }

    }
}