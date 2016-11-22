using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    class LoginWithFireFox
    {
        protected static IWebDriver driver;
        protected static WebDriverWait wait;

        [SetUp]
        public void start()
        {
//            FirefoxOptions options = new FirefoxOptions(); // this is fot FF < version 48
//            options.UseLegacyImplementation = true;
//            driver = new FirefoxDriver(options);

            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginTest()
        {
             string LifecartLoginPage = "http://localhost/litecart/admin/";
            string CssLogin = "[type=\"text\"]";
            string CssPassword = "[type=\"password\"]";
            string CssLoginBtn = "[name=\"login\"]";

            string Login = "admin";
            string Password = "admin";

            driver.Url = LifecartLoginPage;
            driver.FindElement(By.CssSelector(CssLogin)).SendKeys(Login);
            driver.FindElement(By.CssSelector(CssPassword)).SendKeys(Password);
            driver.FindElement(By.CssSelector(CssLoginBtn)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(AdminHomePage.CssLitecartLogo)));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
