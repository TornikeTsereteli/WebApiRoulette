namespace RoulleteGame;

/**
   this class represents players bet Manager strategy
 */
using System;

public class ConcreteBetManager : IBetManager
{
    private static readonly BetType[] PossibleBets = Enum.GetValues(typeof(BetType)) as BetType[];

    public static BetType[] GetPossibleBets()
    {
        return PossibleBets;
    }
    public void MakeBets(Player player)
    {   
        Console.WriteLine($"{player.UserName} make your bets:");

        while (true)
        {
            if (player.Balance <= 0)
            {
                Console.WriteLine("Dealer: sorry you can't make another bet :(, your balance is ZERO");
                break;
            }

            ShowBets();
            Console.WriteLine("Insert your chosen bet:");
            int bet;
            while (!int.TryParse(Console.ReadLine(), out bet) || bet < -1 || bet > 13)
            {
                Console.WriteLine($"Sorry you can't bet on {bet}th, choose a number from -1 to 13:");
            }

            if (bet == 13 || bet == -1)
            {
                break;
            }

            Console.WriteLine("Please also insert the desirable amount of money to bet:");
            int betMoney;
            while (!int.TryParse(Console.ReadLine(), out betMoney) || betMoney <= 0 || !player.CanMakeBet(betMoney))
            {
                Console.WriteLine($"Dealer: you can't bet a negative or zero amount of money, or sorry you can't make a bet :) your balance is {player.Balance}");
                Console.WriteLine("Dealer: please bet money again!");
            }

            player.PlaceBet(betMoney, PossibleBets[bet]);
            Console.WriteLine("Successfully placed a bet");
        }
    }

    private static void ShowBets()
    {
        Console.WriteLine("Here are possible bets:");
        for (var i = 0; i < PossibleBets.Length; i++)
        {
            Console.WriteLine($"{i} -> {PossibleBets[i]}");
        }
        Console.WriteLine("13 | -1 -> FINISHBETS");
    }
}
