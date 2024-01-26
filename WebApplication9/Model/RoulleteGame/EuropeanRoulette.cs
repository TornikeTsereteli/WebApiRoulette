namespace RoulleteGame;

/**
   concrete implementation of Roulette wheel
 */
public class EuropeanRoulette:IRoulette {
private int randomNumber;

public void SpinWheel() {
    Random random = new Random();
    randomNumber = random.Next(0, 36);
}

public int GetNumber() {
    return randomNumber;
}
}