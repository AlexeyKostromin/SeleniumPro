using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class OpentLinksTest : Base
    {
        [Test]
        public void LinksOpensInNewTabsTest()
        {
            AdminHomePage homePage = LoginPage.LoginToAdmin();
            homePage.GoToCountries();

            driver.FindElement(By.CssSelector(".button")).Click();

            string maninWindow = driver.CurrentWindowHandle;
            var allExternalLinks = driver.FindElements(By.CssSelector(".fa.fa-external-link"));
            foreach (var link in allExternalLinks)
            {
                link.Click();
                CloseNewWindowAndReturnToMain(maninWindow);
            }
        }

        public void CloseNewWindowAndReturnToMain(string maninWindow)
        {
            var newWindow = AnyWindowOtherThan(maninWindow);
            driver.SwitchTo().Window(newWindow);
            driver.Close();
            driver.SwitchTo().Window(maninWindow);
        }

        private string AnyWindowOtherThan(string currentWindow)
        {
            List<string> currentWindowsList;
            do
            {
                currentWindowsList = driver.WindowHandles.ToList();
            } while (currentWindowsList.Count <= 1);

            currentWindowsList.RemoveAll(x => x == currentWindow);
            if (currentWindowsList.Any())
            {
                return currentWindowsList[0];
            }
            return "";
        }



    }
}
