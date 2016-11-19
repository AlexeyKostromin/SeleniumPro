using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
