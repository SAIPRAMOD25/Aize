using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.pageObjects
{

    public class CheckoutInformationPage
    {
        private IWebDriver driver;
        public CheckoutInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
      
        //firstName
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement firstName;
       
        //lastName
        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement lastname;
       
        //Postalcode
        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement postcode;

        //continue
        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement Next;

        public void Information(string Name, string Surname, string Pincode)
        {
            firstName.SendKeys(Name);
            lastname.SendKeys(Surname);
            postcode.SendKeys(Pincode);
            Next.Click();
        }



    }
}
