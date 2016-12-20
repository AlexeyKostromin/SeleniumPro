using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class LogsOnProductsPageTest : Base
    {
        [Test]
        public void ProductsPageLoadsWithoutErrorsTest()
        {
            
            LoginPage.LoginToAdmin();

            string CssProducts = "a[href*=\"edit_product&category_id\"]:not([title=\"Edit\"])";
            string productsURL = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

            driver.Url = productsURL;

            var products = driver.FindElements(By.CssSelector(CssProducts));
            for (int i = 0; i < products.Count; i++)
            {
                var nodes = driver.FindElements(By.CssSelector(CssProducts));
                nodes[i].Click();
                Assert.IsFalse(BrowserLogsHasErrors(), "the page has errors in logs");
                driver.Url = productsURL;
            }

        }

        public void GetBrowserLogs()
        {
            foreach (LogEntry l in driver.Manage().Logs.GetLog("browser"))
            {
                Console.WriteLine(l);
            }
        }

        public bool BrowserLogsHasErrors()
        {
            var logsAll = driver.Manage().Logs.GetLog("browser");
            if (logsAll.Any())
            {
                return true;
            }
            return false;

        }
    }
}
