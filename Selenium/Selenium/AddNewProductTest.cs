using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class AddNewProductTest : Base
    {
        [Test]
        public void CanAddNewProductTest()
        {
            AdminHomePage homePage = LoginPage.LoginToAdmin();
            homePage.GoToCatalog();

            driver.FindElement(By.CssSelector(".button[href$=\"edit_product\"]")).Click();

            var statusRadioEnabled = driver.FindElement(By.CssSelector("#tab-general label> [value=\"1\"]"));
            var name = driver.FindElement(By.CssSelector("[name=\"name[en]\"]"));
            var ubberDucksCheck = driver.FindElement(By.CssSelector("[data-name=\"Rubber Ducks\"]"));
            var uniSexCheck = driver.FindElement(By.CssSelector("[name=\"product_groups[]\"][value=\"1-3\"]"));
            var quantity = driver.FindElement(By.CssSelector("[name=\"quantity\"]"));
            var uploadImageBnt = driver.FindElement(By.CssSelector("[name=\"new_images[]\"]"));
            var dateFrom = driver.FindElement(By.CssSelector("[name=\"date_valid_from\"]"));
            var dateTo = driver.FindElement(By.CssSelector("[name=\"date_valid_to\"]"));

            string pathToImage = "E:\\SOS\\GitHub\\steam.png";
            string productName = this.GenerateProductName();
            var saveBtn= driver.FindElement(By.CssSelector("[name=\"save\"]"));

//            bool isSeleced = false;
//            if (!ubberDucksCheck.Selected)
//            {
//                ubberDucksCheck.Click();
//            }
            
            statusRadioEnabled.Click();
            name.SendKeys(productName);
            ubberDucksCheck.Click();
            uniSexCheck.Click();
            quantity.SendKeys("10");
            uploadImageBnt.SendKeys(pathToImage);
            dateFrom.SendKeys("07-12-2016");
            dateTo.SendKeys("07-12-2017");
            
            // open Information tab
            var informationTab = driver.FindElement(By.CssSelector("[href=\"#tab-information\"]"));
            informationTab.Click();

            var manufactirerCombo = driver.FindElement(By.CssSelector("[name=\"manufacturer_id\"]"));
            var supplierCombo = driver.FindElement(By.CssSelector("[name=\"supplier_id\"]"));
            var descriptionShort = driver.FindElement(By.CssSelector("[name=\"short_description[en]\"]"));
            var descriptionPane = driver.FindElement(By.CssSelector(".trumbowyg-editor"));
            var headTitle = driver.FindElement(By.CssSelector("[name=\"head_title[en]\"]"));

            manufactirerCombo.Click();
            var options = driver.FindElements(By.CssSelector("[name=\"manufacturer_id\"] > option"));
            foreach (var option in options)
            {
                string text = option.GetAttribute("innerText");
                if (text == "ACME Corp.")
                {
                    option.Click();
                    break;
                }
            }

            string paneText =
                "Электрический камин Royal Flame 3D Etna VA -2683 с реалистичным 3D эффект горения.\r\n\r\nЗвук горения дров\r\nТермостат для регулирования заданной температуры в помещении\r\nПульт дистанционного управления\r\n";

            descriptionShort.SendKeys("Short Sescription");
            descriptionPane.SendKeys(paneText);
            headTitle.SendKeys("Head Title");

            // open Prices tab
            var priceTab = driver.FindElement(By.CssSelector("[href=\"#tab-prices\"]"));
            priceTab.Click();
            
            var purchasePrice = driver.FindElement(By.CssSelector("[name=\"purchase_price\"]"));
            var currencyCombo = driver.FindElement(By.CssSelector("[name=\"purchase_price_currency_code\"]"));
            var priceUsd = driver.FindElement(By.CssSelector("[name=\"prices[USD]\"]"));

            purchasePrice.SendKeys("1");
            currencyCombo.Click();
            var curencies = driver.FindElements(By.CssSelector("[name=\"purchase_price_currency_code\"]>option"));
            foreach (var item in curencies)
            {
                string text = item.GetAttribute("innerText");
                if (text == "USD")
                {
                    item.Click();
                    break;
                }
            }
            priceUsd.SendKeys("19");

            saveBtn.Click();

            Assert.IsTrue(AdminHomePage.IsProductPresent(productName), "product {0} was not found in catalog", productName);
            
        }
    }
}
