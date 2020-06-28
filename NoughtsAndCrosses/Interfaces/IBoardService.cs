namespace NoughtsAndCrosses.Interfaces
{
    public interface IBoardService
    {
        char[,] BoardState { get; set; }
        int MovesMade { get; set; }
        void CreateNewBoard();
        bool ValidPosition(int row, int column);
        void UpdateBoard(char marker, int row, int column);
    }
}
