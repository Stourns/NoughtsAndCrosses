using NoughtsAndCrosses.Interfaces;
using System;
using NoughtsAndCrosses.Enums;

namespace NoughtsAndCrosses.Services
{
    public class TurnService : ITurnService
    {
        private readonly IInputService _inputService;
        private readonly IResultService _resultService;
        private readonly IConsoleWrapper _consoleWrapper;

        public TurnService(IInputService inputService, IResultService resultService, IConsoleWrapper consoleWrapper)
        {
            _inputService = inputService;
            _resultService = resultService;
            _consoleWrapper = consoleWrapper;
        }

        public GameState TakeTurn(char currentPlayer)
        {
            var moveMade = false;
            while (!moveMade)
            {
                moveMade = MakeMove(currentPlayer);
            }

            return _resultService.CurrentState();
        }

        private bool MakeMove(char currentPlayer)
        {
            Console.WriteLine("Player: {0}, please take your turn by inputting a number between 1-9", currentPlayer);
            var input = _consoleWrapper.ReadLine();
            return _inputService.HandleInput(input, currentPlayer);
        }

    }
}
