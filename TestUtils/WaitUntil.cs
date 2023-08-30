

using NUnitDataDrivenFramework.TestSetup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitDataDrivenFramework;

public class WaitUntil : Base
{
    public static void WaitForElementToBeDisplayed(By element)
    {
        WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
    }

    public static void WaitForElementToBeClickable(By element)
    {
        WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

    }

    public static void WaitForElementToBePresent(By element)
    {
        WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));

    }


}