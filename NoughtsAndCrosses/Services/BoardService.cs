using System;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses.Services
{
    public class BoardService : IBoardService
    {
        private static string EdgeOfBoard => "     |     |      ";
        private static string BoardBreak => "_____|_____|_____ ";

        public char[,] BoardState { get; set; }
        public int MovesMade { get; set; }

        public void CreateNewBoard()
        {
            BoardState = new [,]
            {
                {Constants.EmptySpace, Constants.EmptySpace, Constants.EmptySpace},
                {Constants.EmptySpace, Constants.EmptySpace, Constants.EmptySpace},
                {Constants.EmptySpace, Constants.EmptySpace, Constants.EmptySpace}
            };

            MovesMade = 0;
            DrawCurrentBoardState();
        }

        public bool ValidPosition(int row, int column)
        {
            return BoardState[row, column] == Constants.EmptySpace;
        }

        public void UpdateBoard(char marker, int row, int column)
        {
            BoardState[row, column] = marker;
            DrawCurrentBoardState();
            MovesMade++;
        }

        private void DrawCurrentBoardState()
        {
            Console.Clear();
            Console.WriteLine(EdgeOfBoard);
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardState[0, 0], BoardState[0, 1], BoardState[0, 2]);
            Console.WriteLine(BoardBreak);
            Console.WriteLine(EdgeOfBoard);
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardState[1, 0], BoardState[1, 1], BoardState[1, 2]);
            Console.WriteLine(BoardBreak);
            Console.WriteLine(EdgeOfBoard);
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardState[2, 0], BoardState[2, 1], BoardState[2, 2]);
            Console.WriteLine(EdgeOfBoard);
        }
    }
}
