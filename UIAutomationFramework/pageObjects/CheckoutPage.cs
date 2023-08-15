using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.pageObjects
{
    public class CheckoutPage
    {
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

       // driver.FindElement(By.Id("checkout")).Click();


        //checkoutbutton
        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkout;
        public IWebElement icheckout()
        {
            return checkout;
        }


    }
}
