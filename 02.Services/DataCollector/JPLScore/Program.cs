using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace JPLScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://sporza.be/nl/categorie/voetbal/jupiler-pro-league/";

            var section = driver.FindElement(By.Id("sc-matchdays-uuid-matchdays"));
            var children = section.FindElements(By.XPath(".//li"));

            foreach (var item in children)
            {
                IWebElement homeTeamNameElement = null;
                IWebElement awayTeamNameElement = null;
                IWebElement homeTeamScoreElement = null;
                IWebElement awayTeamScoreElement = null;
                try
                {
                    homeTeamNameElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-scoreboard__team--home')]"));

                    awayTeamNameElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-scoreboard__team--away')]"));

                    homeTeamScoreElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-score__home')]"));
                    awayTeamScoreElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-score__away')]"));
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"{homeTeamNameElement.Text} - {awayTeamNameElement.Text} : not played yet.");
                }

                if (homeTeamNameElement != null && awayTeamNameElement != null && homeTeamScoreElement != null && awayTeamScoreElement != null)
                {
                    var homeTeamScore = int.Parse(homeTeamScoreElement.Text);
                    var awayTeamScore = int.Parse(awayTeamScoreElement.Text);

                    Console.WriteLine($"{homeTeamNameElement.Text} {homeTeamScore} - {awayTeamScore} {awayTeamNameElement.Text}");
                }
            }

            driver.Close();
        }
    }
}
