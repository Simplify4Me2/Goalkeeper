using GoalKeeper.DataCollector.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace JPLScore
{
    public class MatchCollectorVoetbalkrant
    {
        public static List<Match> GetMatchesFromMatchday(int matchday)
        {
            List<Match> matches = new List<Match>();
            Dictionary<Match, string> matchLinks = new Dictionary<Match, string>();

            IWebDriver driver = GetWebDriver();
            driver.Url = $"https://www.voetbalkrant.com/belgie/jupiler-pro-league/kalender/speeldag-{matchday}";

            var tableElement = driver.FindElement(By.XPath(".//table[contains(@class,'table-sm')]"));
            var matchRows = tableElement.FindElements(By.XPath(".//tr[contains(@class,'table-active')]"));

            foreach (var row in matchRows)
            {
                Match match = new() { Matchday = matchday };

                var dataElements = row.FindElements(By.XPath(".//td[contains(@class,'text')]"));
                var dateElement = dataElements.First();
                var homeTeamElement = dataElements[1];
                var scoreElement = dataElements[2];
                var awayTeamElement = dataElements.Last();

                match.Date = MapDate(dateElement.Text);
                match.HomeTeamName = homeTeamElement.Text;
                match.AwayTeamName = awayTeamElement.Text;

                try
                {
                    string[] scores = scoreElement.Text.Trim().Split('-');

                    match.HomeTeamScore = int.Parse(scores.First());
                    match.AwayTeamScore = int.Parse(scores.Last());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{match.HomeTeamName} - {match.AwayTeamName} : not played yet.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                matches.Add(match);
            }

            driver.Close();

            return matches;
        }

        private static DateTime MapDate(string text)
        {
            try
            {
                int day = int.Parse(text.Substring(0, 2));
                int month = int.Parse(text.Substring(3, 2));
                int hour = int.Parse(text.Substring(6, 2));
                int minute = int.Parse(text.Substring(9, 2));

                int year = 0;
                if (month > 6)
                    year = 2021;
                else
                    year = 2022;

                return new DateTime(year, month, day, hour, minute, 00);
            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid date: {text}");
            }
            
            return new DateTime();
        }

        private static IWebDriver GetWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            IWebDriver driver = new ChromeDriver(chromeOptions);
            return driver;
        }
    }

}
