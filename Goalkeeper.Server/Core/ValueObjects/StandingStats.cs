namespace Goalkeeper.Server.Core.ValueObjects;

public class StandingStats(int Played, int Won, int Drawn, int Lost, int GoalsFor, int GoalsAgainst)
{
    public int Points => (Won * 3) + Drawn;
    public int GoalDifference => GoalsFor - GoalsAgainst;

    public static StandingStats Zero => new(0, 0, 0, 0, 0, 0);

    public StandingStats AddWin(int scored, int conceded)
        => new StandingStats(Played + 1, Won + 1, Drawn, Lost, GoalsFor + scored, GoalsAgainst + conceded);

    public StandingStats AddDraw(int scored, int conceded)
        => new StandingStats(Played + 1, Won, Drawn + 1, Lost, GoalsFor + scored, GoalsAgainst + conceded);

    public StandingStats AddLoss(int scored, int conceded)
        => new StandingStats(Played + 1, Won, Drawn, Lost + 1, GoalsFor + scored, GoalsAgainst + conceded);
}
