using GoalKeeper.DataCollector.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JPLScore;
internal class MatchCollectorProLeague
{
    public static List<Match> GetMatchesFromMatchday(int matchday)
    {
        List<Match> matches = new List<Match>();
        Dictionary<Match, string> matchLinks = new Dictionary<Match, string>();

        IWebDriver driver = GetWebDriver();
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
                Match match = new() { Matchday = matchday, Date = date };
                string link = string.Empty;

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

                    var linkElement = element.FindElement(By.XPath(".//a[contains(@class, 'c-match__link')]"));
                    link = linkElement.GetAttribute("href");

                    //Console.WriteLine(link);

                    //try
                    //{
                    //    driver.Navigate().GoToUrl("https://example.com");

                    //    //homeTeamScoreElement.Click();
                    //    //var fooElement = driver.FindElement(By.XPath(".//div[contains(@class,'date')]"));
                    //    //Console.WriteLine($"{fooElement.Text} found!!!");

                    //    Console.WriteLine($"Switching between pages!!!");

                    //    driver.Navigate().GoToUrl($"https://www.proleague.be/nl/jpl/calendar?playDay={matchday}");
                    //}
                    //catch (Exception)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Green;
                    //    Console.WriteLine($"Something wrong.");
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //}


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
                matchLinks.Add(match, link);
            }
        }

        // Blocked until I find a way to open the link for the match and locate the date element...

        //var bar = matchLinks.First();
        //driver.Navigate().GoToUrl(bar.Value);
        ////var foo2 = driver.FindElement(By.XPath("//*[contains(text(), '')]"));
        //var foo2 = driver.FindElement(By.Id("ember2101"));
        //Console.WriteLine(foo2.Text);
        //foo2.Click();

        //foreach (var item in matchLinks)
        //{
        //    driver.Navigate().GoToUrl(item.Value);
        //    try
        //    {
        //        var foo = driver.FindElement(By.XPath("//*[contains(text(), '')]"));
        //        //var foo = driver.FindElement(By.XPath(".//div[contains(@class, 'pre-header')]"));
        //        //var foo = driver.FindElement(By.CssSelector(".date"));
        //        //var foo = driver.FindElement(By.ClassName("pre-header"));
        //        //pre - header
        //        Console.WriteLine(foo.Text);
        //        foo.Click();

        //        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //        //var dateElement = wait.Until(driver => driver.FindElement(By.XPath("//div[contains(@class, 'date')]")));
        //        //var dateElement = wait.Until(driver => driver.FindElement(By.CssSelector("date")));
        //        //var dateElement = driver.FindElement(By.XPath(".//div[contains(@class, 'date')]"));

        //        //var dateElement = driver.FindElement(By.XPath(".//div[contains(@class, 'date')]"));
        //        //Console.WriteLine(dateElement.Text);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //Thread.Sleep(2000);
        //var dateElement = driver.FindElement(By.XPath(".//div[contains(@class, 'date')]"));

        //}
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

    private static IWebDriver GetWebDriver()
    {
        var chromeOptions = new ChromeOptions();
        //chromeOptions.AddArguments("headless");
        chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

        IWebDriver driver = new ChromeDriver(chromeOptions);
        return driver;
    }
}
