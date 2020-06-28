using NoughtsAndCrosses.Enums;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses.Services
{
    public class ResultService : IResultService
    {
        private readonly IBoardService _boardService;
        private readonly int[] _boardPositions = { 0, 1, 2 };
        private static int MaxMoves => 9;
        private static int MinMovesToWin => 5;

        public ResultService(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public GameState CurrentState()
        {
            var numberOfMovesMade = _boardService.MovesMade;
            var boardState = _boardService.BoardState;

            if (numberOfMovesMade >= MinMovesToWin && (RowWin(boardState) || ColumnWin(boardState) || DiagonalWin(boardState)))
            {
                return GameState.Win;
            }

            if (numberOfMovesMade == MaxMoves)
            {
                return GameState.Draw;
            }

            return GameState.InProgress;
        }

        private bool RowWin(char[,] boardState)
        {
            foreach (var position in _boardPositions)
            {
                if (boardState[position, 0] != Constants.EmptySpace &&
                    boardState[position, 0] == boardState[position, 1] &&
                    boardState[position, 0] == boardState[position, 2])
                {
                    return true;
                }
            }

            return false;
        }

        private bool ColumnWin(char[,] boardState)
        {
            foreach (var position in _boardPositions)
            {
                if (boardState[0, position] != Constants.EmptySpace &&
                    boardState[0, position] == boardState[1, position] &&
                    boardState[0, position] == boardState[2, position])
                {
                    return true;
                }
            }

            return false;
        }

        private bool DiagonalWin(char[,] boardState)
        {
            return (boardState[0, 0] != Constants.EmptySpace &&
                    boardState[0, 0] == boardState[1, 1] &&
                    boardState[0, 0] == boardState[2, 2]) ||
                   (boardState[0, 2] != Constants.EmptySpace &&
                    boardState[0, 2] == boardState[1, 1] &&
                    boardState[0, 2] == boardState[2, 0]);
        }
    }
}
