using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.pageObjects
{
    public class Products
    {
        private IWebDriver driver;
        public Products(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Shirt
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bolt-t-shirt")]
        private IWebElement shirt;

        public IWebElement getItem()
        {
            return shirt;
        }


        //Bagpack
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement backpack;

        public IWebElement GetItem1()
        {
            return backpack;
        }


        //Cart
        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement cart;

        public IWebElement Cart()
        {
            return cart;
        }

        //Shirtprice
        [FindsBy(How = How.CssSelector, Using = "div:nth-child(3) div:nth-child(2) div:nth-child(2) div:nth-child(1)")]
        private IWebElement shirtcost;

        public IWebElement Shirtprice()
        {
            return shirtcost;
        }





    }
}
