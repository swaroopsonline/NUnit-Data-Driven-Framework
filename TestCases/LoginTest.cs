using NUnitDataDrivenFramework.PageObjects;
using NUnitDataDrivenFramework.TestSetup;
using OpenQA.Selenium;

namespace NUnitDataDrivenFramework;

[Parallelizable(ParallelScope.Self)]
// [Parallelizable(ParallelScope.Children)]
public class LoginTest : Base
{
    [Test]
    [TestCaseSource("GetTestData")]
    // [TestCase()]
    // [TestCase("anytest@hmail.com","efthth")]
    public void VerifyLogin(string email, string password)
    {
        // driver.FindElement(By.Id("email")).SendKeys("testemail@ymail.com");
        // driver.FindElement(By.Id("pass")).SendKeys("asdfsd");

        FacebookLandingPage fblandingpage = new FacebookLandingPage();
        // fblandingpage.InvalidLogin("testemail@tmail.com", "kafskdaf");
        fblandingpage.InvalidLogin(email, password);
        Thread.Sleep(5000);
        // if (!homepageelement.isDisplayed())
        // {
        //     Assert.Fail("homepage element is not displayed");
        // }
        Assert.Fail();

    }

    [Test]
    public void VerifyLoginDummy()
    {

        FacebookLandingPage fblandingpage = new FacebookLandingPage();
        fblandingpage.InvalidLogin("asfdf@umail.com", "klasfj8798");
        Thread.Sleep(5000);

    }

    public static IEnumerable<TestCaseData> GetTestData()
    {
        // yield return new TestCaseData("test1@hmail.com","dafsfdaasdf");
        // yield return new TestCaseData("test2@hmail.com","czvcvcvcfd");

        yield return new TestCaseData(getDataReader().GetTestData("validEmail"), getDataReader().GetTestData("validPassword"));

    }

}