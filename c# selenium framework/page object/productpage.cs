using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace c__selenium_framework.page_object
{
    internal class productpage
    {   //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        //  IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
        private IWebDriver driver;
        By addtocart = By.CssSelector(".card-footer button");
        internal productpage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutbutton;
        public void Waitforcheckoutpagedisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }
        public IList<IWebElement>Getcards() 
        {
            return cards;   
        }
        public By addtocartbutton()
        {
            return addtocart;
        }
        public Checkoutpage Checkout()
        {
            checkoutbutton.Click();
            return new Checkoutpage(driver);
        }



    }
}
