using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class MenuTest : Base
    {
        [Test]
        public void AllMenuElementsTest()
        {
            AdminHomePage homePage = LoginPage.LoginToAdmin();
            var mainNodesBlock = driver.FindElements(By.CssSelector(AdminHomePage.CssNodes));

            for (int i = 0; i < mainNodesBlock.Count; i++)
            {
                var nodes = driver.FindElements(By.CssSelector(AdminHomePage.CssNodes));
                nodes[i].Click();

                Assert.IsTrue(this.IsElementPresent(By.CssSelector(AdminHomePage.CssHeader)), "element {0} was not found", AdminHomePage.CssHeader);

                var subNodesCount = driver.FindElements(By.CssSelector(AdminHomePage.CssSubNodes)).Count;
                if (subNodesCount != 0)
                {
                    for (int j = 0; j < subNodesCount; j++)
                    {
                        var subNodes = driver.FindElements(By.CssSelector(AdminHomePage.CssSubNodes));
                        subNodes[j].Click();
                        Assert.IsTrue(this.IsElementPresent(By.CssSelector(AdminHomePage.CssHeader)), "element {0} was not found", AdminHomePage.CssHeader);
                    }
                }
                
            }


        }
    }
}
