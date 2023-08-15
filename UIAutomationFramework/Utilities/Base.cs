using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace UIAutomationFramework.Utilities
{
    public class Base
    {
        public ExtentReports extentReports;
        public ExtentTest test;
        [OneTimeSetUp]
            public void Setup() 
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                String reportPath = projectDirectory + "//index.html";
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                extentReports.AttachReporter(htmlReporter);
                extentReports.AddSystemInfo("Username", "Sai Pramod");
            }
        
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()

       {
                test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
                String browserName = ConfigurationManager.AppSettings["browser"];
                IntBrowser(browserName);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Manage().Window.Maximize();
                driver.Url = "https://www.saucedemo.com/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void IntBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
            }
            else if (status == TestStatus.Passed)
            {
            }
            extentReports.Flush();
            driver.Quit();
        }
    }
}
