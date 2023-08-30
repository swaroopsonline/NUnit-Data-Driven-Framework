using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using NUnitDataDrivenFramework.TestUtils;

namespace NUnitDataDrivenFramework.TestSetup;

[TestFixture]
public class Base
{
    // public static IWebDriver driver;
    public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


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

        string browserKey = ConfigurationManager.AppSettings["browser"];
        this.InitBrowser(browserKey);

        driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        driver.Value.Url = ConfigurationManager.AppSettings["testURL"];

    }

    [TearDown]
    public void TearDown()
    {

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