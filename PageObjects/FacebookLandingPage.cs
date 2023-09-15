using System;
using NUnitDataDrivenFramework.TestSetup;
using NUnitDataDrivenFramework.TestUtils;
using OpenQA.Selenium;
using static NUnitDataDrivenFramework.TestUtils.BrowserActions;

namespace NUnitDataDrivenFramework.PageObjects;

public class FacebookLandingPage : Base
{
    public By Email = By.Id("email");
    public By Password = By.Id("pass");
    public By LoginButton = By.Name("login");
    public By CreateAccount = By.XPath("//a[text()='Create new account']");
    public By FirstName = By.Name("firstname");
    public By SurName = By.Name("lastname");
    public By continueButton = By.XPath("//button[text()='Yes Continue']");
    public By invalidPasswordErrorMessage = By.XPath("//div[contains(text(), 'Invalid username or password')]");

   
    public void Login(string email, string pass)
    {
        // driver.FindElement(Email).SendKeys(email);
        BrowserActions.Type(Email, email);
        // driver.FindElement(Password).SendKeys(pass);
        BrowserActions.Type(Password, pass);
        // driver.FindElement(LoginButton).Click();
        BrowserActions.Click(LoginButton);
        // Assert Home Page is displayed
    }

    public void InvalidLogin(string email, string pass)
    {
        // driver.FindElement(Email).SendKeys(email);
        BrowserActions.Type(Email, email);
        // driver.FindElement(Password).SendKeys(pass);
        BrowserActions.Type(Password, pass);
        // driver.FindElement(LoginButton).Click();
        BrowserActions.Click(LoginButton);

        BrowserActions.InvalidLoginDisplayedErrorMessage();

    }

    public void LoginWithInvalidPassword(string email, string pass)
    {
        // driver.FindElement(Email).SendKeys(email);
        BrowserActions.Type(Email, email);
        // driver.FindElement(Password).SendKeys(pass);
        BrowserActions.Type(Password, pass);
        // driver.FindElement(LoginButton).Click();
        BrowserActions.Click(LoginButton);

        BrowserActions.InvalidLoginDisplayedErrorMessage();

    }

    public void SignUp(string firstName, string lastName)
    {
        BrowserActions.Click(CreateAccount);
        BrowserActions.Type(FirstName, firstName);
        BrowserActions.Type(SurName, lastName);
        
    }

}

