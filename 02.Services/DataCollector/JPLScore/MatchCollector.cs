using GoalKeeper.Stats.Application.IO.CommandModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPLScore
{
    internal class MatchCollector
    {
        public static List<MatchPlayedModel> GetMatchesFromMatchday(int matchday)
        {
            List<MatchPlayedModel> matches = new List<MatchPlayedModel>();

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://sporza.be/nl/categorie/voetbal/jupiler-pro-league/";

            var section = driver.FindElement(By.Id("sc-matchdays-uuid-matchdays"));

            var header = section.FindElements(By.XPath(".//h2"));
            var selectedMatchday = int.Parse(header[0].Text.Split(' ').ToList().Last());

            var children = section.FindElements(By.XPath(".//li"));

            foreach (var item in children)
            {
                MatchPlayedModel match = new() { Matchday = selectedMatchday };
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

                if (homeTeamNameElement != null && awayTeamNameElement != null && homeTeamScoreElement != null && awayTeamScoreElement != null)
                {
                    var homeTeamScore = int.Parse(homeTeamScoreElement.Text);
                    match.HomeTeamScore = homeTeamScore;

                    var awayTeamScore = int.Parse(awayTeamScoreElement.Text);
                    match.AwayTeamScore = awayTeamScore;

                    //Console.WriteLine($"{homeTeamNameElement.Text} {homeTeamScore} - {awayTeamScore} {awayTeamNameElement.Text}");
                }
                matches.Add(match);
            }

            driver.Close();

            return matches;
        }
    }
}
