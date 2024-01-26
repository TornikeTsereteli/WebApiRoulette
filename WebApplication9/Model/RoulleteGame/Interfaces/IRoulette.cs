namespace RoulleteGame;

/**
   interface represents a roulette wheel in a roulette game.
   It defines methods for spinning the wheel and retrieving the resulting number.
 */

public interface IRoulette {
    void SpinWheel();
    int GetNumber();
}