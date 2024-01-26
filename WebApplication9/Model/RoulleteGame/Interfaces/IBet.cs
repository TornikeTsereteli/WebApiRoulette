namespace RoulleteGame;

/**
 * interface represents a betting option in a roulette game.
 * Implementations of this interface define specific types of bets that can be placed.
 * 
 * A bet has two main responsibilities:
 * 1.Determine whether the bet wins based on the lucky number spun on the roulette wheel.
 * 2. Calculate the profit or loss associated with the bet.
 * 
 * concrete implementations are EvenOddBet, RedBlackBet, ThreeIntervalBet, NumberBet, Mod3Bet, HalfIntervalBet
 * 
 * *
 */
public interface IBet
{
    bool IsWinningBet(int luckyNumber);
    int GetProfit();
}