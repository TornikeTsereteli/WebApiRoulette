namespace RoulleteGame;

/**
 * this class represent number bet:
 * example:
 * Bet number3Bet = new NumberBet(20,3);
 */
public class NumberBet : IBet
{
    private readonly int betMoney;
    private readonly int usersLuckyNumber;

    public NumberBet(int betMoney, int usersLuckyNumber)
    {
        ValidateBetMoney(betMoney);
        ValidateUserLuckyNumber(usersLuckyNumber);
        this.betMoney = betMoney;
        this.usersLuckyNumber = usersLuckyNumber;
    }


    public bool IsWinningBet(int luckyNumber)
    {
        ValidateUserLuckyNumber(luckyNumber);
        return luckyNumber == usersLuckyNumber;
    }


    public int GetProfit()
    {
        return betMoney * 36;
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