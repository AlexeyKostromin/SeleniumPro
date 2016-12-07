using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium
{
    public class LoginPage : Base
    {
        private const string LifecartLoginPage = "http://localhost/litecart/admin/";
        private const string LifecartHomePage = "http://localhost/litecart/en/";
        private const string CssCreateAccount = "[href=\"http://localhost/litecart/en/create_account\"]";
        private const string CssLogin = "[type=\"text\"]";
        private const string CssPassword = "[type=\"password\"]";
        private const string CssLoginBtn = "[name=\"login\"]";
        

        private const string Login = "admin";
        private const string Password = "admin";

        public static AdminHomePage LoginToAdmin()
        {
            driver.Url = LifecartLoginPage;
            driver.FindElement(By.CssSelector(CssLogin)).SendKeys(Login);
            driver.FindElement(By.CssSelector(CssPassword)).SendKeys(Password);
            driver.FindElement(By.CssSelector(CssLoginBtn)).Click();
            return new AdminHomePage();
        }

        public static void GotoCreateAccountPage()
        {
            driver.Url = LifecartHomePage;
            driver.FindElement(By.CssSelector(CssCreateAccount)).Click();
        }

        public static void LoginAsUser(string email, string password)
        {
            driver.Url = LifecartHomePage;
            driver.FindElement(By.CssSelector(CssLogin)).SendKeys(email);
            driver.FindElement(By.CssSelector(CssPassword)).SendKeys(password);
            driver.FindElement(By.CssSelector(CssLoginBtn)).Click();

        }
        
    }
}
