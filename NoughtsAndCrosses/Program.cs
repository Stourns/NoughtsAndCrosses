using System;
using NoughtsAndCrosses.Services;
using NoughtsAndCrosses.Wrapper;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardService = new BoardService();
            var consoleWrapper = new ConsoleWrapper();
            var inputService = new InputService(boardService);
            var resultService = new ResultService(boardService);
            var turnService = new TurnService(inputService, resultService, consoleWrapper);
            
            var game = new GameService(turnService, boardService);
            game.Play();
            Console.ReadLine();
        }
    }
}

