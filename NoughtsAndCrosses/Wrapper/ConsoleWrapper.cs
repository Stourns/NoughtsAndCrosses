using System;
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses.Wrapper
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
