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
        
    }
}
