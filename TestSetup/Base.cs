using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using NUnitDataDrivenFramework.TestUtils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;

namespace NUnitDataDrivenFramework.TestSetup;

[TestFixture]
public class Base
{
    // public static IWebDriver driver;
    public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
    public ExtentReports extent;
    public ExtentTest extenttest;

    [OneTimeSetUp]
    public void TestSuiteSetup()
    {
        string workingDirectory = Environment.CurrentDirectory; //Get path of Base.cs
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string reportPath = projectDirectory + "/index.html";

        ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        extent.AddSystemInfo("Host Name", "Local Host");
        extent.AddSystemInfo("Environment", "QA");
        extent.AddSystemInfo("UserName", "Swp-Automation");

    }

    [SetUp]
    public void Setup()
    {

        string relativeConfigPath = "app.config";
        // Console.WriteLine("Relative Path is: " + relativeConfigPath);
        string customConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeConfigPath);
        // Console.WriteLine("Custom Config Path is: " + customConfigPath);

        // Set the custom configuration file path for the current AppDomain
        AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", customConfigPath);

        // Refresh the configuration to apply the changes
        ConfigurationManager.RefreshSection("appSettings");

        extenttest = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        string browserKey = ConfigurationManager.AppSettings["browser"];
        this.InitBrowser(browserKey);

        driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        driver.Value.Url = ConfigurationManager.AppSettings["testURL"];

    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        if (status == TestStatus.Failed)
        {
            extenttest.Fail("Test Case Failed");
        }
        else if (status == TestStatus.Passed)
        {
            extenttest.Pass("Test Case Passed");
        }
        extent.Flush(); // Flush method is important for the method to get generated.

        if (driver != null)
        {
            driver.Value.Quit();
        }

    }

    public static JsonReader getDataReader()
    {
        return new JsonReader();

    }

    public static IWebDriver GetDriver()
    {
        return driver.Value;

    }


    public void InitBrowser(string browserName)
    {


        switch (browserName.ToLower())
        {
            
            case "chrome":
                driver.Value = new ChromeDriver();
                driver.Value.Manage().Window.Maximize();
                break;
            case "firefox":
                driver.Value = new FirefoxDriver();
                driver.Value.Manage().Window.Maximize();
                break;
            case "safari":
                driver.Value = new SafariDriver();
                driver.Value.Manage().Window.Maximize();
                break;
        }

    }


}