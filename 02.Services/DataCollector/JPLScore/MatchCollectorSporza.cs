using GoalKeeper.DataCollector.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace JPLScore
{
    internal class MatchCollectorSporza
    {
        public static List<Match> GetMatchesFromMatchday(int matchday)
        {
            List<Match> matches = new List<Match>();

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://sporza.be/nl/categorie/voetbal/jupiler-pro-league/";

            // Get rid of the GDPR pop-up
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.XPath("//*[text() = 'Accept All']")).Click();
            driver.SwitchTo().DefaultContent();


            var section = driver.FindElement(By.Id("sc-matchdays-uuid-matchdays"));

            var header = section.FindElements(By.XPath(".//h2"));
            var selectedMatchday = int.Parse(header[0].Text.Split(' ').ToList().Last());

            var children = section.FindElements(By.XPath(".//li"));

            foreach (var item in children)
            {
                Match match = new() { Matchday = selectedMatchday };
                IWebElement homeTeamNameElement = null;
                IWebElement awayTeamNameElement = null;
                IWebElement homeTeamScoreElement = null;
                IWebElement awayTeamScoreElement = null;
                try
                {
                    homeTeamNameElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-scoreboard__team--home')]"));
                    match.HomeTeamName = homeTeamNameElement.Text;

                    awayTeamNameElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-scoreboard__team--away')]"));
                    match.AwayTeamName = awayTeamNameElement.Text;

                    homeTeamScoreElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-score__home')]"));
                    awayTeamScoreElement = item.FindElement(By.XPath(".//span[contains(@class,'sc-score__away')]"));

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"{homeTeamNameElement.Text} - {awayTeamNameElement.Text} : not played yet.");
                }

                var homeTeamScore = int.Parse(homeTeamScoreElement.Text);
                match.HomeTeamScore = homeTeamScore;

                var awayTeamScore = int.Parse(awayTeamScoreElement.Text);
                match.AwayTeamScore = awayTeamScore;

                //item.Click();
                //var matchDateElement = driver.FindElements(By.XPath(".//span[contains(@class,'sc-metadata__item')]")).ToList().Last();
                //driver.Navigate().Back();

                //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 30));
                ////wait.Until(ExpectedConditions.visibilityOfElementLocated(By.xpath("xpathValue")));
                //wait.Until<IWebElement>(foo => foo.FindElement(By.XPath(".//div[contains(@class,'sc-metadata')]")));

                //Console.WriteLine($"{homeTeamNameElement.Text} {homeTeamScore} - {awayTeamScore} {awayTeamNameElement.Text}");
                matches.Add(match);
            }

            driver.Close();

            return matches;
        }
    }
}
