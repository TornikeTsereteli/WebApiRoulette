namespace RoulleteGame;

using System;
using System.Collections.Generic;
using System.Threading;

public class RouletteGame
{
    private readonly IRoulette _roulette;
    private readonly List<Player> _players = new List<Player>();
    private readonly IBetManager _betManager;

    public RouletteGame(IRoulette roulette, IBetManager betManager)
    {
        _roulette = roulette ?? throw new ArgumentNullException(nameof(roulette));
        _betManager = betManager ?? throw new ArgumentNullException(nameof(betManager));
    }

    private static void ValidateLuckyNumber(int luckyNumber)
    {
        if (luckyNumber < 0 || luckyNumber > 36)
        {
            throw new ArgumentException("lucky number must be in range [0-36]");
        }
    }

    void NotifyAllPlayers(int luckyNumber)
    {
        ValidateLuckyNumber(luckyNumber);
        foreach (var player in _players)
        {
            player.AddWinningMoneyToBalance(luckyNumber);
            player.ShowWinningMoney(luckyNumber);
        }
    }

    private void AddPlayers()
    {
        Console.WriteLine("Enter how many players will participate in the roulette game:");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Number of players should be a positive number.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            var player = new Player($"Player{i}");
            _players.Add(player);
        }
    }

    private void AddBalanceToPlayers()
    {
        foreach (var player in _players)
        {
            Console.WriteLine($"{player.UserName} add money to your balance if you wish, if not insert 0:");
            if (!int.TryParse(Console.ReadLine(), out int balance) || balance < 0)
            {
                Console.WriteLine("Dealer: You can't deposit a negative number. Please insert a positive integer!");
                continue;
            }

            player.AddBalance(balance);
        }
    }

    public void StartGame()
    {
        Console.WriteLine("Game Starts!!!");
        AddPlayers();

        while (true)
        {
            AddBalanceToPlayers();

            foreach (var player in _players)
            {
                _betManager.MakeBets(player);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Roulette spins....");
            Thread.Sleep(1000);

            _roulette.SpinWheel();
            int luckyNumber = _roulette.GetNumber();
            Console.WriteLine($"Lucky Number is {luckyNumber}");

            NotifyAllPlayers(luckyNumber);

            Console.WriteLine("Dealer: Players! Do you wish to continue the game? If yes, input Y, else input any character");
            string input = Console.ReadLine();

            foreach (var player in _players)
            {
                player.ClearBets();
            }

            if (!input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }

    // public static void Main(string[] args)
    // {
    //     RouletteGame rouletteGame = new RouletteGame(new EuropeanRoulette(), new ConcreteBetManager());
    //     rouletteGame.StartGame();
    // }
}
