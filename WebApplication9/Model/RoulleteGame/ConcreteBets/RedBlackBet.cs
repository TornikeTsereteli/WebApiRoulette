namespace RoulleteGame;

public class RedBlackBet: IBet {
private readonly bool isRed;
private readonly int betMoney;

public RedBlackBet(int betMoney, bool isRed) {
    ValidateBetMoney(betMoney);
    this.betMoney = betMoney;
    this.isRed = isRed;
}

private static void ValidateBetMoney(int betMoney) {
    if (betMoney < 0) throw new ArgumentException("bet money should not be negative!");
}


private static readonly HashSet<int> LuckyRedNumbers = new HashSet<int>{2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35};
private static readonly HashSet<int> LuckyBlackNumbers = new HashSet<int>{1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 30, 32, 34, 36};

private static void ValidateLuckyNumber(int luckyNumber) {
    if (luckyNumber < 0 || luckyNumber > 36) {
        throw new ArgumentException("lucky number should be in range [0-36]");
    }
}


public bool IsWinningBet(int luckyNumber) {
    ValidateLuckyNumber(luckyNumber);
    if (isRed)
        return LuckyRedNumbers.Contains(luckyNumber);
    return LuckyBlackNumbers.Contains(luckyNumber);
}


public int GetProfit() {
    return betMoney * 2;
}
}