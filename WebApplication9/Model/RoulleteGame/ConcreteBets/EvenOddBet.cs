namespace RoulleteGame;

/**
 * this class represent Even or Odd Bet
 * example of red bet:
 * Bet evenBet = new EvenOddBet(4,true);
 * example of black Bet:
 * Bet evenBet = new EvenOddBet(4,false);
 */
public class EvenOddBet : IBet
{
    private readonly int betMoney;

    private readonly bool isEven;

    public EvenOddBet(int betMoney, bool isEven)
    {
        ValidateBetMoney(betMoney);
        this.betMoney = betMoney;
        this.isEven = isEven;
    }


    public bool IsWinningBet(int luckyNumber)
    {
        ValidateUserLuckyNumber(luckyNumber);
        if (luckyNumber == 0) return false;
        return isEven ? luckyNumber % 2 == 0 : luckyNumber % 2 == 1;
    }

    public int GetProfit()
    {
        return betMoney * 2;
    }

    private void ValidateBetMoney(int betMoney)
    {
        if (betMoney < 0) throw new ArgumentException("bet money should not be negative!");
    }

    private void ValidateUserLuckyNumber(int usersLuckyNumber)
    {
        if (usersLuckyNumber < 0 || usersLuckyNumber > 36)
            throw new ArgumentException("lucky number should be in range [0,36]");
    }
}