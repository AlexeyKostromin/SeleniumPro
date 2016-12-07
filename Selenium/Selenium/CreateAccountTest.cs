using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class CreateAccountTest : Base
    {
        [Test]
        public void CanRegisterNewUserTest()
        {
            LoginPage.GotoCreateAccountPage();

            var firstNameField = driver.FindElement(By.CssSelector("[name=\"firstname\"]"));
            var lastNameField = driver.FindElement(By.CssSelector("[name=\"lastname\"]"));
            var address1Field = driver.FindElement(By.CssSelector("[name=\"address1\"]"));
            var address2Field = driver.FindElement(By.CssSelector("[name=\"address2\"]"));
            var postCodeField = driver.FindElement(By.CssSelector("[name=\"postcode\"]"));
            var cityField = driver.FindElement(By.CssSelector("[name=\"city\"]"));
            var emailField = driver.FindElement(By.CssSelector("[name=\"email\"]"));
            var phoneField = driver.FindElement(By.CssSelector("[name=\"phone\"]"));
            var passwordField = driver.FindElement(By.CssSelector("[name=\"password\"]"));
            var confirmPassField = driver.FindElement(By.CssSelector("[name=\"confirmed_password\"]"));
            var createAccountBtn = driver.FindElement(By.CssSelector("[name=\"create_account\"]"));

            driver.FindElement(By.CssSelector(".select2-selection__arrow")).Click();

            //            var countriesListElements = driver.FindElements(By.CssSelector(".select2-results__option"));
            //            foreach (var element in countriesListElements)
            //            {
            //                var countryName = element.GetAttribute("innerText");
            //                if (countryName == "Afghanistan")
            //                {
            //                    element.Click();
            //                    break;
            //                }
            //
            //            }

            var searchField = driver.FindElement(By.CssSelector(".select2-search__field"));
            searchField.SendKeys("Afghanistan" + Keys.Enter);

            firstNameField.SendKeys("test_first_name");
            lastNameField.SendKeys("test_last_name");
            address1Field.SendKeys("Address1");
            postCodeField.SendKeys("123456");
            cityField.SendKeys("City");
            var email = this.GenerateEmail();
            emailField.SendKeys(email);
            phoneField.SendKeys("123456789");
            var password = "password";
            passwordField.SendKeys(password);
            confirmPassField.SendKeys("password");

            createAccountBtn.Click();

            string logoutLink = "[href=\"http://localhost/litecart/en/logout\"]";
            var logoutBtn = driver.FindElement(By.CssSelector(logoutLink));
            logoutBtn.Click();

            LoginPage.LoginAsUser(email, password);

            logoutBtn = driver.FindElement(By.CssSelector(logoutLink));
            logoutBtn.Click();

        }
    }
}
