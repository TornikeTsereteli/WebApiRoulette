using System.Text.RegularExpressions;

namespace RoulleteGame;

public class BetParser
{
    public static List<IBet> ParseBets(string input)
    {
        var bets = new List<IBet>();

        // Regular expression pattern to match "(type,amount)"
        var regex = new Regex(@"\(([^,]+),(\d+)\)");
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            var type = match.Groups[1].Value.Trim();
            var amount = int.Parse(match.Groups[2].Value.Trim());

            var betType = BetTypeExtensions.FromString(type);
            var bet = SimpleBetFactory.createBet(amount, betType);
            if (bet != null) bets.Add(bet);
        }

        return bets;
    }

    // public static void Main(string[] args)
    // {
    //     string input = "(red,12),(mod3Equals1,23),(Number ,100),(Odd,12)";
    //     List<Bet> bets = ParseBets(input);
    //
    //     foreach (Bet bet in bets)
    //     {
    //         Console.WriteLine($"Type: {bet.GetType().Name}, Amount: {bet.GetProfit()}");
    //     }
    // }
}