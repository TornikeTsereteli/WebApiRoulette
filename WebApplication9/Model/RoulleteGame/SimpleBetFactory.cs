namespace RoulleteGame;

/**
   simple factory class for Bet creation
 */

using System;

public class SimpleBetFactory
{
    public static IBet createBet(int betMoney, BetType betType)
    {
        switch (betType)
        {
            case BetType.RED:
                return new RedBlackBet(betMoney, true);
            case BetType.BLACK:
                return new RedBlackBet(betMoney, false);
            case BetType.EVEN:
                return new EvenOddBet(betMoney, true);
            case BetType.ODD:
                return new EvenOddBet(betMoney, false);
            case BetType.MOD3EQUALS0:
                return new ModThreeBet(betMoney, 0);
            case BetType.MOD3EQUALS1:
                return new ModThreeBet(betMoney, 1);
            case BetType.MOD3EQUALS2:
                return new ModThreeBet(betMoney, 2);
            case BetType.FIRSTINTERVAL:
                return new ThreeIntervalBet(betMoney, 1);
            case BetType.SECONDINTERVAL:
                return new ThreeIntervalBet(betMoney, 2);
            case BetType.THIRDINTERVAL:
                return new ThreeIntervalBet(betMoney, 3);
            case BetType.FIRSTHALF:
                return new HalfIntervalBet(betMoney, true);
            case BetType.SECONDHALF:
                return new HalfIntervalBet(betMoney, false);
            case BetType.NUMBER:
                Console.WriteLine("Please Insert your Lucky Number:");
                int luckyNumber;
                while (!int.TryParse(Console.ReadLine(), out luckyNumber) || luckyNumber < 0 || luckyNumber > 37)
                {
                    Console.WriteLine("Your lucky number should be in range [0-36], please insert again:");
                }
                return new NumberBet(betMoney, luckyNumber);
        }
        return null;
    }
}
