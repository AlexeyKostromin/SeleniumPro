using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class CountryAndGeozoneSorting : Base
    {
        [Test]
        public void CountrySortingTest()
        {
            AdminHomePage homePage = LoginPage.LoginToAdmin();
            homePage.GoToCountries();

            // verify that countries have orrect order
            var listOfCountriesForSorting = homePage.GetAllCountries();
            listOfCountriesForSorting.Sort();
            var listOfCountriesUnsorted = homePage.GetAllCountries();

            Assert.AreEqual(listOfCountriesForSorting, listOfCountriesUnsorted);

            var listOfCountriesNames = new List<string>();
            var listOfZonesIndex = new List<string>();
            
            var rowsFull = driver.FindElements(By.CssSelector(".dataTable .row"));
            foreach (var webElement in rowsFull)
            {
                listOfCountriesNames.Add(webElement.FindElement(By.CssSelector("td:nth-of-type(5) a")).GetAttribute("innerText"));
                listOfZonesIndex.Add(webElement.FindElement(By.CssSelector("td:nth-of-type(6)")).Text);
            }

//            var listOfZoneIndexes = listOfZones.Select((s,i) =>new{s,i}).Where(p => p.s != "0").Select(p=>p.i).ToList();

            var listOfIndexesWithZones = new List<int>(); // above string doing same sorting

            for (int i = 0; i < listOfZonesIndex.Count; i++)
            {
                if (listOfZonesIndex[i] != "0")
                {
                    listOfIndexesWithZones.Add(i);
                }
            }

            // find countries with zones
            var listOfCountriesWithZones = new List<string>();

            for (int i = 0; i < listOfIndexesWithZones.Count; i++)
            {
                listOfCountriesWithZones.Add(listOfCountriesNames[listOfIndexesWithZones[i]]);
            }

            // verify that zones for every counrty have correct order of zones
            foreach (var country in listOfCountriesWithZones)
            {
                driver.FindElement(By.XPath(".//*[@class='dataTable']//a[text()='" + country + "']")).Click();
                var listOfSybZonesForSorting = homePage.GetAllZonesFromSubZones();
                listOfSybZonesForSorting.Sort();
                var listOfSybZonesUnsorted = homePage.GetAllZonesFromSubZones();

                Assert.AreEqual(listOfSybZonesForSorting, listOfSybZonesUnsorted);

                homePage.GoToCountries();
            }

        }

        [Test]
        public void GeoZonesSortingTest()
        {
            AdminHomePage homePage = LoginPage.LoginToAdmin();
            homePage.GoToGeozones();

            var geoZonesMainCount = driver.FindElements(By.XPath(".//*[@class='dataTable']//tr/td[3]/a")).Count;

            for (int i = 0; i < geoZonesMainCount; i++)
            {
                var zones = driver.FindElements(By.XPath(".//*[@class='dataTable']//tr/td[3]/a"));
                zones[i].Click();
                var listOfZonesForSorting = homePage.GetAllZones();
                listOfZonesForSorting.Sort();

                var listOfZonesUnsorted = homePage.GetAllZones();

                Assert.AreEqual(listOfZonesForSorting, listOfZonesUnsorted);

                homePage.GoToGeozones();
            }

        }
    }
}
