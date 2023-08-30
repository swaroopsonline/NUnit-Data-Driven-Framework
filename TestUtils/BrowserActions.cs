using NUnitDataDrivenFramework.TestSetup;
using OpenQA.Selenium;

namespace NUnitDataDrivenFramework.TestUtils;

public class BrowserActions : Base
{
    public static void Type(By field, string value)
    {
        WaitUntil.WaitForElementToBeDisplayed(field);
        GetDriver().FindElement(field).SendKeys(value);

    }

    public static void Click(By field)
    {
        WaitUntil.WaitForElementToBeClickable(field);
        GetDriver().FindElement(field).Click();
    }

    public static void InvalidLoginDisplayedErrorMessage()
    {
        // Locate the error message element
        IWebElement errorMessageElement = GetDriver().FindElement(By.XPath("//div[contains(text(), 'Invalid username or password')]"));

        // Get the text of the error message
        string errorMessage = errorMessageElement.Text;

        // Perform the assertion to check if the error message matches the expected text
        Assert.AreEqual("Invalid username or password", errorMessage);


    }

}