using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium
{
    public class AdminHomePage : Base
    {
        internal const string CssLitecartLogo = "[title=\"My Store\"]";
        internal const string CssHeader = "h1";
        internal const string CssNodes = "#app-";
        internal const string CssSubNodes = "[class=docs] > li";

        internal const string XpathCountries = ".//ul[@id='box-apps-menu']//span[text()='Countries']"; // css = .dataTable a[href*='edit_country']:not([title])
        internal const string CssCountry = ".dataTable td:nth-of-type(5) a"; // xpath = "//table[@class='dataTable']//tr/td[5]/a"

        internal const string XpathGeoZones = ".//ul[@id='box-apps-menu']//span[text()='Geo Zones']";
        internal const string XpathZoneName = ".//*[@class='dataTable']//tr/td[3]/a";

        public AdminHomePage GoToCountries()
        {
            driver.FindElement(By.XPath(XpathCountries)).Click();
            
            return new AdminHomePage();
        }

        public AdminHomePage GoToGeozones()
        {
            driver.FindElement(By.XPath(XpathGeoZones)).Click();

            return new AdminHomePage();
        }

        public List<string> GetAllCountries()
        {
            List<string> countries = new List<string>();
            int rowsCount = driver.FindElements(By.CssSelector(CssCountry)).Count;
            for (int i = 0; i < rowsCount; i++)
            {
                var nodes = driver.FindElements(By.CssSelector(CssCountry));
                countries.Add(nodes[i].GetAttribute("innerText"));
            }

            return countries;
        }

        public List<string> GetAllZoneNames()
        {
            List<string> zones = new List<string>();
            int rowsCount = driver.FindElements(By.XPath(XpathZoneName)).Count;
            for (int i = 0; i < rowsCount; i++)
            {
                var nodes = driver.FindElements(By.XPath(XpathZoneName));
                zones.Add(nodes[i].GetAttribute("innerText"));
            }

            return zones;
        }

        public List<string> GetAllZones()
        {
            List<string> zonesList = new List<string>();

            var zones = driver.FindElements(By.CssSelector("[name$=\"[zone_code]\"] [selected=\"selected\"]"));

            foreach (var element in zones)
            {
                zonesList.Add(element.GetAttribute("innerText"));
            }

            return zonesList;
        }

        public List<string> GetAllZonesFromSubZones()
        {
            List<string> zonesList = new List<string>();

            var zones = driver.FindElements(By.CssSelector("#table-zones tr>td:nth-of-type(3)"));

            foreach (var element in zones)
            {
                if (element.Text == "")
                {
                    continue;
                }
                zonesList.Add(element.Text);
            }

            return zonesList;
        }
        



    }
}
