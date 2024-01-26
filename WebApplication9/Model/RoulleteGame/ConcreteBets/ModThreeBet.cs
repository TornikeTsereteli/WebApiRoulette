namespace RoulleteGame;

/**
 * this class represents such bets:
 * win money if lucky number is divided 3 reminder is 0 or 1 or 2
 * example of lucky number mod 3 equals 0:
 * Bet mod3Equals0Bet = new ModThreeBet(4,0)
 * for mod 3 == 1:
 * Bet mod3Equals1Bet = new ModThreeBet(4,1)
 * for mod 3 == 2
 * Bet mod3Equals2Bet = new ModThreeBet(4,0)
 */
public class ModThreeBet : IBet
{
    private readonly int betMoney;
    private readonly int mod;

    public ModThreeBet(int betMoney, int mod)
    {
        ValidateBetMoney(betMoney);
        ValidateMod(mod);

        this.betMoney = betMoney;
        this.mod = mod;
    }


    public bool IsWinningBet(int luckyNumber)
    {
        return luckyNumber % 3 == mod && luckyNumber != 0;
    }


    public int GetProfit()
    {
        return betMoney * 3;
    }

    private static void ValidateBetMoney(int betMoney)
    {
        if (betMoney < 0) throw new ArgumentException("bet money should not be negative!");
    }

    private static void ValidateMod(int mod)
    {
        if (mod > 2 || mod < 0) throw new ArgumentException("mod should be 0 1 2!!! ");
    }
}