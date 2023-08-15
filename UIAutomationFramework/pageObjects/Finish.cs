using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.pageObjects
{
    public class Finish
    {
        private IWebDriver driver;
        public Finish(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElement(By.Id("finish")).Click();


        //Finish button
        [FindsBy(How = How.Id, Using = "finish")]
        private IWebElement finish;
        public IWebElement Submit()
        {
            return finish;
        }

        //TotalPrice
        [FindsBy(How = How.CssSelector, Using = "#checkout_summary_container > div > div.summary_info > div.summary_info_label.summary_total_label")]
        private IWebElement totalprice;
        public IWebElement Final_Price()
        {
            return totalprice;
        }
    }
}
