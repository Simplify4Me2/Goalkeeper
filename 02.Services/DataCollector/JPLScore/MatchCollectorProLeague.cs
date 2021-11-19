using GoalKeeper.Stats.Application.IO.CommandModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace JPLScore;
internal class MatchCollectorProLeague
{
    public static List<MatchPlayedModel> GetMatchesFromMatchday(int matchday)
    {
        List<MatchPlayedModel> matches = new List<MatchPlayedModel>();

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("headless");

        IWebDriver driver = new ChromeDriver(chromeOptions);
        driver.Url = $"https://www.proleague.be/nl/jpl/calendar?playDay={matchday}";

        var section = driver.FindElement(By.XPath(".//div[contains(@class,'c-match-collection')][1]"));

        var children = section.FindElements(By.XPath(".//div[not(@id) and not(@class)]"));

        foreach (var item in children)
        {
            var dateElement = item.FindElement(By.XPath(".//h4[contains(@class,'c-match-collection__subtitle')]"));
            //Console.WriteLine(dateElement.Text);

            DateTime date = ToDateTime(dateElement.Text);

            var matchElements = item.FindElements(By.CssSelector(".c-match"));
            foreach (var element in matchElements)
            {
                MatchPlayedModel match = new() { Matchday = matchday, Date = date };

                var teamElements = element.FindElements(By.XPath(".//div[contains(@class,'c-match__team')]")).ToList();
                match.HomeTeamName = teamElements.First().FindElement(By.XPath(".//a[contains(@class,'c-link')]")).Text;
                match.AwayTeamName = teamElements.Last().FindElement(By.XPath(".//a[contains(@class,'c-link')]")).Text;

                try
                {
                    var scoreElements = element.FindElements(By.XPath(".//span[contains(@class,'c-match__nr')]")).ToList();
                    var homeTeamScoreElement = scoreElements.First();
                    var awayTeamScoreElement = scoreElements.Last();

                    match.HomeTeamScore = int.Parse(homeTeamScoreElement.Text);
                    match.AwayTeamScore = int.Parse(awayTeamScoreElement.Text);

                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine($"{match.HomeTeamName} vs {match.AwayTeamName}: {match.HomeTeamScore} - {match.AwayTeamScore}");
                    //Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{match.HomeTeamName} - {match.AwayTeamName} : not played yet.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                matches.Add(match);
            }
        }

        driver.Close();

        return matches;
    }

    private static DateTime ToDateTime(string text)
    {
        var strings = text.Split(' ').ToList();
        int day = int.Parse(strings[1]);
        int month = MonthToInt(strings[2]);
        int year = int.Parse(strings.Last());
        return new DateTime(year, month, day);
    }

    private static int MonthToInt(string monthName)
    {
        switch (monthName)
        {
            case "januari":
                return 1;
            case "februari":
                return 2;
            case "maart":
                return 3;
            case "april":
                return 4;
            case "mei":
                return 5;
            case "juni":
                return 6;
            case "juli":
                return 7;
            case "augustus":
                return 8;
            case "september":
                return 9;
            case "oktober":
                return 10;
            case "november":
                return 11;
            case "december":
                return 12;
            default:
                throw new ArgumentException(nameof(monthName));
        }
    }
}
