using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Username
        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement username;

        //password
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        //loginbutton
        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement login;

        //  String Actual_Message = driver.FindElement(By.CssSelector(".error-message-container.error")).Text;
        [FindsBy(How = How.CssSelector, Using = ".error-message-container.error")]
        private IWebElement errormessage;
        public IWebElement Error()
        {
            return errormessage;
        }

        public void SignIN(string userid,string secret)
        {
            username.SendKeys(userid);
            password.SendKeys(secret);
            login.Click();
        }
    }
}
