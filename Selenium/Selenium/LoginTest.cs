using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    [TestFixture]
    public class LoginTest : Base
    {

        [Test]
        public void CanLoginWithValidCredentialsTest()
        {
            LoginPage.LoginToAdmin();
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(AdminHomePage.CssLitecartLogo)));
            
        }

    }
}
