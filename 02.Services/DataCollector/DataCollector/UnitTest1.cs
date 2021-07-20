using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataCollector
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Url = "https://sporza.be/nl/";
            driver.Url = "https://sporza.be/nl/categorie/voetbal/jupiler-pro-league/";

            // Address sign “@” full name textbox
            //driver.findElement(By.xpath("//input[contains(@id, 'userN')]")).sendKeys("Full Name");

            //var inpoutElement = driver.FindElement(By.Id("vrt-link--toggle-voetbal"));
            //inpoutElement.Click();

            var section = driver.FindElement(By.Id("sc-matchdays-uuid-matchdays"));

            Assert.NotNull(section);

            driver.Close();
        }
    }
}
