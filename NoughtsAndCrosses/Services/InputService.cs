using System;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses.Services
{
    public class InputService : IInputService
    {
        private readonly IBoardService _boardService;

        public InputService(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public bool HandleInput(string input, char currentPlayer)
        {
            if (InputIsValidInteger(input))
            {
                if (input == "1" && _boardService.ValidPosition(0, 0))
                {
                    return UpdateBoard(currentPlayer, 0, 0);
                }

                if (input == "2" && _boardService.ValidPosition(0, 1))
                {
                    return UpdateBoard(currentPlayer, 0, 1);
                }

                if (input == "3" && _boardService.ValidPosition(0, 2))
                {
                    return UpdateBoard(currentPlayer, 0, 2);
                }

                if (input == "4" && _boardService.ValidPosition(1, 0))
                {
                    return UpdateBoard(currentPlayer, 1, 0);
                }

                if (input == "5" && _boardService.ValidPosition(1, 1))
                {
                    _boardService.UpdateBoard(currentPlayer, 1, 1);
                    return true;
                }

                if (input == "6" && _boardService.ValidPosition(1, 2))
                {
                    return UpdateBoard(currentPlayer, 1, 2);
                }

                if (input == "7" && _boardService.ValidPosition(2, 0))
                {
                    return UpdateBoard(currentPlayer, 2, 0);
                }

                if (input == "8" && _boardService.ValidPosition(2, 1))
                {
                    return UpdateBoard(currentPlayer, 2, 1);
                }

                if (input == "9" && _boardService.ValidPosition(2, 2))
                {
                    return UpdateBoard(currentPlayer, 2, 2);
                }
            }

            Console.WriteLine("Input invalid! Please input a valid number in a position that is not taken.");
            return false;
        }

        private bool InputIsValidInteger(string input)
        {
            return int.TryParse(input, out int num) && num != 0;
        }

        private bool UpdateBoard(char currentPlayer, int row, int column)
        {
            _boardService.UpdateBoard(currentPlayer, row, column);
            return true;
        }
    }
}
