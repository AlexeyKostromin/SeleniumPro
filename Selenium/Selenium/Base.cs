using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Base
    {
        protected static IWebDriver driver;
        protected static WebDriverWait wait;

        protected static string homePageUrl = "http://localhost/litecart/en/";

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementPresentByCount(By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        public Random random = new Random();

        public string GenerateEmail()
        {
            return string.Format("test_email_" + "{0}" + "@mail.com", random.Next(10000, 99999));
        }

        public string GenerateProductName()
        {
            return string.Format("test_product_" + "{0}", random.Next(10000, 99999));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
