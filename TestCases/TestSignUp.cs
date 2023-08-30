
using NUnitDataDrivenFramework.PageObjects;
using NUnitDataDrivenFramework.TestSetup;

namespace NUnitDataDrivenFramework;

[Parallelizable(ParallelScope.Self)]
public class TestSignUp : Base
{
    [Test, TestCaseSource("GetTestData")]
    public void VerifySignUp(string firstName, string lastName)
    {
        FacebookLandingPage fblandingpage = new FacebookLandingPage();
        fblandingpage.SignUp(firstName, lastName);
    }

    public static IEnumerable<TestCaseData> GetTestData()
    {        

        yield return new TestCaseData(getDataReader().GetTestData("firstName"), getDataReader().GetTestData("lastName"));
        
    }

}