using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Numerics;
using System.Reflection.Metadata;
using c__selenium_framework.utilities;

namespace seleniumlearning
{
    internal class Windowhandler : Base
    {
        

        [Test]  
        public void Windowhandle()
        {
            String email = "mentor@rahulshettyacademy.com";
            driver.FindElement(By.CssSelector("a[class='blinkingText']")).Click();
            // confirm how ma y windows are opened
            String parentwindow =driver.WindowHandles[0];
            Assert.AreEqual(2, driver.WindowHandles.Count);
            //switch to the window using the index
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //get test on the child window
           TestContext.Progress.WriteLine( driver.FindElement(By.CssSelector("p[class='im-para red']")).Text);
            // to extract the email from the text
            String textonpage = driver.FindElement(By.CssSelector("p[class='im-para red']")).Text;
            //Please email us at mentor@rahulshettyacademy.com with below template to receive response
            String[] splittedtext = textonpage.Split("at");
            String[] trimmedtext=splittedtext[1].Trim().Split(" ");
            Assert.AreEqual(email, trimmedtext[0]);
            TestContext.Progress.WriteLine(trimmedtext[0]);
            //switch to parent window
            driver.SwitchTo().Window(parentwindow);
            // fil the parent window into the usernamefiled
            driver.FindElement(By.Id("username")).SendKeys(trimmedtext[0]);






        }
    }
}
