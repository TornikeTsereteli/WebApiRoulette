using WebApplication9.Model;

namespace RoulleteGame;

/**
 * class represents a player participating in a roulette game.
 * Each player has a name, an initial balance, and the ability to place bets on the game.
 * 
 * example of usage:
 * Player player = new Player("player0", 100);
 * 
 * // Place bets on different types
 * player.placeBet(20, BetType.ODD);
 * player.placeBet(30, BetType.FIRSTINTERVAL);
 */
public class Player
{
    
    public int PlayerId { get; set; }
    public string UserName { get; private set; }
    public Decimal Balance { get;  set; }
    
    public DateTime CreatedAt { get; set; }

    private List<IBet> bets = new List<IBet>();
    private int bettedMoney;

   


    public Player(RPlayer roulettePlayer)
    {
        UserName = roulettePlayer.Username;
        CreatedAt = roulettePlayer.CreatedAt;
        PlayerId = roulettePlayer.PlayerId;
        Balance = roulettePlayer.Balance;
    }
    public Player(string userName)
    {
        UserName = userName;
    }

    public Player(string userName, int balance)
    {
        ValidateBalance(balance);
        UserName = userName;
        Balance = balance;
    }

    


    private static void ValidateBetMoney(decimal betMoney)
    {
        if (betMoney <= 0) throw new ArgumentException("bet Money should be positive number!!");
    }


    private static void ValidateBalance(int balance)
    {
        if (balance < 0) throw new ArgumentException("balance should be more than or equal to 0");
    }

    public void AddBalance(decimal money)
    {
        if (money != 0) ValidateBetMoney(money);
        Balance += money;
    }

    public void PlaceBet(int betMoney, BetType betType)
    {
        ValidateBalance(betMoney);
        bettedMoney += betMoney;
        Balance -= betMoney;
        bets.Add(SimpleBetFactory.createBet(betMoney, betType));
    }

    public bool CanMakeBet(int betMoney)
    {
        ValidateBetMoney(betMoney);
        return betMoney <= Balance;
    }


    private int GetWinningMoney(int luckyNumber)
    {
        ValidateLuckyNumber(luckyNumber);
        return bets.Where(x => x.IsWinningBet(luckyNumber)).Select(x => x.GetProfit()).Sum();
    }


    public string ShowWinningMoney(int luckyNumber)
    {
        ValidateLuckyNumber(luckyNumber);
        var winningMoney = GetWinningMoney(luckyNumber) - bettedMoney;
        if (winningMoney >= 0)
            return $"{UserName} have Won {winningMoney} Gel and his balance is {Balance} GEL";
        else
            return $"{UserName} have lost  {winningMoney} Gel and his balance is  {Balance} GEL";
    }

    private static void ValidateLuckyNumber(int luckyNumber)
    {
        if (luckyNumber < 0 || luckyNumber > 36)
            throw new ArgumentException("lucky number should be in the range [0-36]");
    }

    public void AddWinningMoneyToBalance(int luckyNumber)
    {
        ValidateBetMoney(luckyNumber);
        AddBalance(GetWinningMoney(luckyNumber));
    } 
    
    public void ClearBets()
    {
        bets = new List<IBet>();
        bettedMoney = 0;
    }
}