using NUnitDataDrivenFramework.PageObjects;
using NUnitDataDrivenFramework.TestSetup;
using NUnitDataDrivenFramework.TestUtils;
using OpenQA.Selenium;

namespace NUnitDataDrivenFramework;

[Parallelizable(ParallelScope.Self)]
// [Parallelizable(ParallelScope.Children)]
public class LoginTest : Base
{
    [Test]
    [TestCaseSource("GetTestDataInvalidPassword")]
    // [TestCase()]
    // [TestCase("anytest@hmail.com","efthth")]
    public void VerifyLoginWithInvalidPassword(string email, string password)
    {
        FacebookLandingPage fblandingpage = new FacebookLandingPage();
        fblandingpage.LoginWithInvalidPassword(email, password);
       
        if (driver.Value.FindElement(fblandingpage.invalidPasswordErrorMessage).Displayed)
        {
            Assert.Pass("Invalid Error Message Occurred");
            test.Info("Invalid Password Message Occurred");

        }
        else
        {
            test.Info("Invalid Password Message Does Not Occur");
            Assert.Fail("Error Message not occurred");

        }

    }

    /*
    [Test]
    [TestCaseSource("GetTestDataInvalidEmail")]
    public void VerifyLoginWithInvalidEmail(string email, string password)
    {

        FacebookLandingPage fblandingpage = new FacebookLandingPage();
        fblandingpage.InvalidLogin(email, password);
        Thread.Sleep(5000);

        Assert.Fail();

    }

    [Test]
    [TestCaseSource("GetTestDataValidCredentials")]
    public void VerifyLoginWithEmptyPassword(string email, string password)
    {

        FacebookLandingPage fblandingpage = new FacebookLandingPage();

        fblandingpage.InvalidLogin(email, "");
        Thread.Sleep(5000);

        Assert.Fail();

    }

    [Test]
    [TestCaseSource("GetTestDataValidCredentials")]
    public void VerifyLoginWithEmptyEmail(string email, string password)
    {

        FacebookLandingPage fblandingpage = new FacebookLandingPage();

        fblandingpage.InvalidLogin("", password);
        Thread.Sleep(5000);

        Assert.Fail();

    }

    [Test]
    [TestCaseSource("GetTestDataValidCredentials")]
    public void VerifyLoginWithValidCredentials(string email, string password)
    {

        FacebookLandingPage fblandingpage = new FacebookLandingPage();

        fblandingpage.InvalidLogin(email, password);
        Thread.Sleep(5000);

        Assert.Fail();

    }
    */


    public static IEnumerable<TestCaseData> GetTestDataValidCredentials()
    {
        // yield return new TestCaseData("test1@hmail.com","dafsfdaasdf");
        // yield return new TestCaseData("test2@hmail.com","czvcvcvcfd");

        yield return new TestCaseData(getDataReader().GetTestData("validEmail"), getDataReader().GetTestData("validPassword"));

    }

    public static IEnumerable<TestCaseData> GetTestDataInvalidPassword()
    {

        yield return new TestCaseData(getDataReader().GetTestData("validEmail"), getDataReader().GetTestData("InvalidPassword"));

    }

    public static IEnumerable<TestCaseData> GetTestDataInvalidEmail()
    {

        yield return new TestCaseData(getDataReader().GetTestData("InvalidEmail"), getDataReader().GetTestData("validPassword"));

    }

}