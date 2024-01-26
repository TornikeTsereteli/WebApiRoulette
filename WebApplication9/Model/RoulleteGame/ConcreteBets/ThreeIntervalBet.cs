namespace RoulleteGame;


/**
  this class represents such bets
  win if the number is in range [1-12]  example: Bet firstIntervalBet = new ThreeInterval(50,1);
  win if the number is in range [13-24] example: Bet secondIntervalBet = new ThreeInterval(50,2);
  win if the number is in range [25-36] example: Bet thirdIntervalBet = new ThreeInterval(50,3);

 */
public class ThreeIntervalBet: IBet {
private readonly int interval;
private readonly int betMoney;

public ThreeIntervalBet(int betMoney, int interval) {
    ValidateBetMoney(betMoney);
    ValidateInterval(interval);
    this.betMoney = betMoney;
    this.interval = interval;
}

private static void ValidateBetMoney(int betMoney) {
    if (betMoney < 0) throw new ArgumentException("bet money should not be negative!");
}

private static void ValidateLuckyNumber(int luckyNumber) {
    if (luckyNumber < 0 || luckyNumber > 36) {
        throw new ArgumentException("lucky number should be in range [0-36]");
    }
}

private static void ValidateInterval(int interval) {
    if (interval < 1 || interval > 3) {
        throw new ArgumentException("interval should be in range [1-3]!!!");
    }
}


public bool IsWinningBet(int luckyNumber) {
    ValidateLuckyNumber(luckyNumber);
    return luckyNumber > (interval - 1) * 12 && luckyNumber <= interval * 12;
}


public int GetProfit() {
    return betMoney * 3;
}

}