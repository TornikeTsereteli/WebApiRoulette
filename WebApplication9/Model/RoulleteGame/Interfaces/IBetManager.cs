namespace RoulleteGame;

/**
 * interface represents a component responsible for managing bets in a roulette game.
 * Implementations of this interface handle the process of players making bets during a betting round.
 */
public interface IBetManager
{
    void MakeBets(Player player);
}