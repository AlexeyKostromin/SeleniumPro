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
    }
}
