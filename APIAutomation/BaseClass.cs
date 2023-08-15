using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace APIAutomation
{
    public class BaseClass
    {
        protected static IRestClient _client;
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

        [OneTimeSetUp]
        public static void IntializeRestClient()
        {
            _client = new RestClient(baseUrl: "https://petstore.swagger.io/v2/user");
        }

        [SetUp]
        public void BeforeTest()

        {
            test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
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
        }
    }
}

