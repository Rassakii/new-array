using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__selenium_framework.page_object
{
    internal class Checkoutpage
    {
        private IWebDriver driver;

        public Checkoutpage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    
    
        //[FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutcards() 
        {
            return driver.FindElements(By.CssSelector("h4 a"));
        }
        //[FindsBy(How = How.CssSelector, Using = "button[class*='btn-success]")]
        private IWebElement successbuton()
        {
            return driver.FindElement(By.CssSelector("button[class*='btn-success']"));

        }


        public IList<IWebElement> getthecards()
        {
            return checkoutcards();
        }
       
       public Finalpage Success()
       {
            successbuton().Click();
            return new Finalpage(driver);
       }
    }
    
}
