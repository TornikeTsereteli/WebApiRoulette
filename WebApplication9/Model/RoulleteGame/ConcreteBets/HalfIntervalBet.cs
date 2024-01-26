namespace RoulleteGame;

/**
 * this class represents First half or Second Half Bet
 * example of First half bet
 * Bet bet = new HalfInterval(5,true);
 * example of second half bet:
 * Bet bet = new HalfInterval(9,false)
 */
public class HalfIntervalBet : IBet
{
    private readonly int betMoney;
    private readonly bool isFirstHalf;

    public HalfIntervalBet(int betMoney, bool isFirstHalf)
    {
        ValidateBetMoney(betMoney);
        this.betMoney = betMoney;
        this.isFirstHalf = isFirstHalf;
    }


    public bool IsWinningBet(int luckyNumber)
    {
        ValidateBetMoney(luckyNumber);
        return isFirstHalf ? luckyNumber > 0 && luckyNumber < 19 : luckyNumber > 18 && luckyNumber < 37;
    }


    public int GetProfit()
    {
        return betMoney * 2;
    }

    private static void ValidateBetMoney(int betMoney)
    {
        if (betMoney < 0) throw new ArgumentException("bet money should not be negative!");
    }

    private static void ValidateUserLuckyNumber(int usersLuckyNumber)
    {
        if (usersLuckyNumber < 0 || usersLuckyNumber > 36)
            throw new ArgumentException("lucky number should be in range [0,36]");
    }
}