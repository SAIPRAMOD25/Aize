using Microsoft.VisualStudio.CodeCoverage;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UIAutomationFramework.pageObjects;
using UIAutomationFramework.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace UIAutomationFramework.Tests
{
    public class Tests : Base
    {

        [Test]
        public void Invalid_Login_Credentials()
        {
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.SignIN("locked_out_user", "secret_sauce");
            String Actual_Message = loginPage.Error().Text;
            String Expected_Message = "Epic sadface: Sorry, this user has been locked out.";
            Assert.AreEqual(Expected_Message, Actual_Message); 
        }

        [Test]
        public void Valid_Login_Credentials()
        {
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.SignIN("standard_user", "secret_sauce");
        }

        [Test]

        public void AddItemstoCart()
        {

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.SignIN("standard_user", "secret_sauce");
            Products product = new Products(getDriver());
            CheckoutPage checkout = new CheckoutPage(getDriver()); 
            CheckoutInformationPage informationPage = new CheckoutInformationPage(getDriver());
            Finish finish = new Finish(getDriver());

            //Add Shirt into the cart
            product.getItem().Click();
            string shirt_price = product.Shirtprice().Text;

            //Assert Shirt Price
            string expected_shirtprice = "$15.99";
            Assert.AreEqual(expected_shirtprice, shirt_price);

            //Add backpak into the cart
            product.GetItem1().Click();
            product.Cart().Click();

            //Page for Checkout
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("checkout")));
            checkout.icheckout().Click();

            //Page for Checkout Information
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("continue")));
            informationPage.Information("Test", "Aize", "KT19");
            //informationPage.Information("Test","Aize","KT19");

            //Page for Checkout Overview
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("finish")));

            //Assert the total price
            string Total_Price = finish.Final_Price().Text;
            string Expected_TotalPrice = "Total: $49.66";
            Assert.AreEqual(Expected_TotalPrice, Total_Price);
            finish.Submit().Click();
        }



        

    }
}