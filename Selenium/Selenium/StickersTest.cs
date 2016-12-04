using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class StickersTest : Base
    {

        [Test]
        public void EveryItemHasStickerTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            var products = driver.FindElements(By.CssSelector("[class^=product]"));

            for (int i = 0; i < products.Count; i++)
            {
                var sticker = products[i].FindElements(By.CssSelector(".sticker"));
                Assert.IsTrue(sticker.Count == 1, "item {0} has {1} stickers, but should have only 1", i, sticker.Count);

            }
        }

        [Test]
        public void ProductPriceTest()
        {
            driver.Url = "http://localhost/litecart/en/";

            var campaignsItems = driver.FindElements(By.CssSelector("#box-campaigns li> .link"));

            var firstItemUrlMain = campaignsItems[0].GetAttribute("href");
            var firstItemTitleMain = campaignsItems[0].GetAttribute("title");

            var regularPriceMain = campaignsItems[0].FindElement(By.CssSelector("[class=\"price-wrapper\"] > [class=\"regular-price\"]"));
            var regularPriceValue = regularPriceMain.GetAttribute("innerText");
            var regularPriceMainColor = regularPriceMain.GetCssValue("color");
            var regularPriceMainSize = regularPriceMain.GetCssValue("font-size");
            var regularPriceMainDecoration = regularPriceMain.GetCssValue("text-decoration");

                var colorRegularPriceMainValid = "rgba(119, 119, 119, 1)";
                var sizeRegularPriceMainValid = "14.4px";
                var textRegularPriceDecorationMainValid = "line-through";

                Assert.AreEqual(colorRegularPriceMainValid, regularPriceMainColor);
                Assert.AreEqual(sizeRegularPriceMainValid, regularPriceMainSize);
                Assert.AreEqual(textRegularPriceDecorationMainValid, regularPriceMainDecoration);
            
            var customPriceMain = campaignsItems[0].FindElement(By.CssSelector("[class=\"price-wrapper\"] > [class=\"campaign-price\"]"));
            var customPriceMainValue = customPriceMain.GetAttribute("innerText");
            var customPriceMainColor = customPriceMain.GetCssValue("color");
            var customPriceMainSize = customPriceMain.GetCssValue("font-size");
            var customPriceMainBold = customPriceMain.GetCssValue("font-weight");

                var colorCustomPriceMainValid = "rgba(204, 0, 0, 1)";
                var sizeCustomPriceMainValid = "18px";
                var textCustomPriceDecorationMainValid = "bold";
            
                Assert.AreEqual(colorCustomPriceMainValid, customPriceMainColor);
                Assert.AreEqual(sizeCustomPriceMainValid, customPriceMainSize);
                Assert.AreEqual(textCustomPriceDecorationMainValid, customPriceMainBold);
                
            campaignsItems[0].Click();
            
            var url = driver.Url;
            var itemTitle = driver.FindElement(By.CssSelector("h1.title")).GetAttribute("innerText");
            var regularPrice = driver.FindElement(By.CssSelector(".regular-price")).GetAttribute("innerText");
            var customPrice = driver.FindElement(By.CssSelector(".campaign-price")).GetAttribute("innerText");

                Assert.AreEqual(firstItemUrlMain, url);
                Assert.AreEqual(firstItemTitleMain, itemTitle);
                Assert.AreEqual(regularPriceValue, regularPrice);
                Assert.AreEqual(customPriceMainValue, customPrice);

        }
    }
}
