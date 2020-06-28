using NoughtsAndCrosses.Enums;

namespace NoughtsAndCrosses.Interfaces
{
    public interface ITurnService
    {
        GameState TakeTurn(char currentPlayer);
    }
}
