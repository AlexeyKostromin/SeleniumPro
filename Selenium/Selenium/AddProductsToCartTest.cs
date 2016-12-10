using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class AddProductsToCartTest : Base
    {
        [Test]
        public void CanAddAndRemoveProductsTest()
        {
            // add first product to cart
            OpenFirstProductFromGomePage();

            int productsInCartBeforeBuy = GetAmountOfCartItems();

            var addToCartBtn = driver.FindElement(By.CssSelector("[name=\"add_cart_product\"]"));
            addToCartBtn.Click();

            int currentCartItemsCount = IfCartItemsCountChanged(productsInCartBeforeBuy);

            Assert.AreEqual(productsInCartBeforeBuy + 1, currentCartItemsCount);
            
            // add second product to cart
            OpenFirstProductFromGomePage();

            productsInCartBeforeBuy = GetAmountOfCartItems();

            addToCartBtn = driver.FindElement(By.CssSelector("[name=\"add_cart_product\"]"));
            addToCartBtn.Click();

            currentCartItemsCount = IfCartItemsCountChanged(productsInCartBeforeBuy);

            Assert.AreEqual(productsInCartBeforeBuy + 1, currentCartItemsCount);

            // add third product to cart
            OpenFirstProductFromGomePage();

            productsInCartBeforeBuy = GetAmountOfCartItems();

            addToCartBtn = driver.FindElement(By.CssSelector("[name=\"add_cart_product\"]"));
            addToCartBtn.Click();

            currentCartItemsCount = IfCartItemsCountChanged(productsInCartBeforeBuy);

            Assert.AreEqual(productsInCartBeforeBuy + 1, currentCartItemsCount);

            var checkoutBtn = driver.FindElement(By.CssSelector(".link[href=\"http://localhost/litecart/en/checkout\"]"));
            checkoutBtn.Click();

            RemoveAllProductsFromCart();

            Assert.IsTrue(wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class=\"dataTable rounded-corners\"] tbody"))));
        }

        protected int IfCartItemsCountChanged(int currentCount)
        {
            for (int i = 0; i < 5; i++)
            {
                int productsInCart = GetAmountOfCartItems();
                if (productsInCart == currentCount + 1)
                {
                    return productsInCart;
                }
                Thread.Sleep(1000);
            }
            throw new Exception("Product was not added to cart within 5 seconds");
        }


        public int GetAmountOfCartItems()
        {
            return Int32.Parse(driver.FindElement(By.CssSelector("#cart .quantity")).GetAttribute("innerText"));
        }

        public void OpenFirstProductFromGomePage()
        {
            driver.Url = homePageUrl;
            var products = driver.FindElements(By.CssSelector("[class^=product]"));
            products[0].Click();
            var prodName = driver.FindElement(By.CssSelector("h1")).GetAttribute("innerText");
            if (prodName == "Yellow Duck")
            {
                OpenFirstProductFromGomePage();
            }
        }

        public void RemoveAllProductsFromCart()
        {
            var smallPictures = driver.FindElements(By.CssSelector(".shortcuts>li"));
            if (smallPictures.Count != 0)
            {
                smallPictures[0].Click();
            }
            
            for (int i = 0; i < smallPictures.Count; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[name=\"remove_cart_item\"]"))).Click();
                wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.CssSelector("[class=\"dataTable rounded-corners\"] tbody"))));
            }

            
        }
    }
}
