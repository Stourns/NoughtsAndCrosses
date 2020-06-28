using NoughtsAndCrosses.Enums;
using NoughtsAndCrosses.Interfaces;
using System;

namespace NoughtsAndCrosses.Services
{
    public class GameService : IGameService
    {
        private readonly ITurnService _turnService;
        private readonly IBoardService _boardService;

        private static char _currentPlayer;

        public GameService(ITurnService turnService, IBoardService boardService)
        {
            _turnService = turnService;
            _boardService = boardService;
        }

        public bool Play()
        {
            var gameState = GameState.InProgress;
            SetUpNewGame();
            while (gameState == GameState.InProgress)
            {
                gameState = _turnService.TakeTurn(_currentPlayer);
                if (gameState == GameState.InProgress)
                {
                    SwapPlayer();
                }
            }

            if (gameState == GameState.Win)
            {
                Console.WriteLine("Congratulations! Player {0} wins!", _currentPlayer);
            }

            if (gameState == GameState.Draw)
            {
                Console.WriteLine("Draw! Better luck next time!");
            }

            return true;
        }

        private void SetUpNewGame()
        {
            _currentPlayer = Constants.PlayerOneMarker;
            _boardService.CreateNewBoard();
        }

        private void SwapPlayer()
        {
            _currentPlayer = _currentPlayer == Constants.PlayerOneMarker ? Constants.PlayerTwoMarker : Constants.PlayerOneMarker;
        }
    }
}
