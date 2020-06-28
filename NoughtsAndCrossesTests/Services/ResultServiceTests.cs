using Moq;
using NoughtsAndCrosses;
using NoughtsAndCrosses.Enums;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Services;
using NUnit.Framework;

namespace NoughtsAndCrossesTests.Services
{
    [TestFixture]
    class ResultServiceTests
    {
        private Mock<IBoardService> _boardService;
        private IResultService _resultService;

        [SetUp]
        public void Setup()
        {
            _boardService = new Mock<IBoardService>();
            _resultService = new ResultService(_boardService.Object);
        }

        [TestCase(1, ExpectedResult = GameState.InProgress)]
        [TestCase(2, ExpectedResult = GameState.InProgress)]
        [TestCase(3, ExpectedResult = GameState.InProgress)]
        [TestCase(4, ExpectedResult = GameState.InProgress)]
        public GameState CurrentState_GivenMovesMadeLessThan5_ReturnsInProgress(int movesMade)
        {
            _boardService.Setup(x => x.MovesMade).Returns(movesMade);

            return _resultService.CurrentState();
        }

        [Test]
        public void CurrentState_GivenGameIsDraw_ReturnsDraw()
        {
            var boardState = new [,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerTwoMarker, Constants.PlayerOneMarker },
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker }
            };
            _boardService.Setup(x => x.MovesMade).Returns(9);
            _boardService.Setup(x => x.BoardState).Returns(boardState);

            var result =_resultService.CurrentState();

            Assert.That(result, Is.EqualTo(GameState.Draw));
        }

        [Test]
        public void CurrentState_GivenGameIsFirstRowWin_ReturnsWin()
        {
            var boardState = new [,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerOneMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerTwoMarker, Constants.EmptySpace },
                {Constants.EmptySpace, Constants.EmptySpace, Constants.EmptySpace }
            };

            AssertWin(5, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsSecondRowWin_ReturnsWin()
        {
            var boardState = new[,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerTwoMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.EmptySpace }
            };

            AssertWin(8, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsThirdRowWin_ReturnsWin()
        {
            var boardState = new[,]
            {
                {Constants.EmptySpace, Constants.EmptySpace, Constants.PlayerOneMarker },
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.EmptySpace },
                {Constants.PlayerTwoMarker, Constants.PlayerTwoMarker, Constants.PlayerTwoMarker }
            };

            AssertWin(6, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsFirstColumnWin_ReturnsWin()
        {
            var boardState = new[,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerTwoMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerOneMarker, Constants.EmptySpace, Constants.PlayerTwoMarker },
                {Constants.PlayerOneMarker, Constants.EmptySpace, Constants.PlayerOneMarker }
            };

            AssertWin(7, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsSecondColumnWin_ReturnsWin()
        {
            var boardState = new[,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.EmptySpace, Constants.PlayerOneMarker, Constants.EmptySpace }
            };

            AssertWin(7, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsThirdColumnWin_ReturnsWin()
        {
            var boardState = new [,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerOneMarker, Constants.EmptySpace, Constants.PlayerTwoMarker }
            };

            AssertWin(8, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsFirstDiagonalWin_ReturnsWin()
        {
            var boardState = new [,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.EmptySpace, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.EmptySpace, Constants.PlayerTwoMarker, Constants.PlayerOneMarker }
            };

            AssertWin(7, boardState);
        }

        [Test]
        public void CurrentState_GivenGameIsSecondDiagonalWin_ReturnsWin()
        {
            var boardState = new[,]
            {
                {Constants.PlayerOneMarker, Constants.PlayerOneMarker, Constants.PlayerTwoMarker },
                {Constants.PlayerOneMarker, Constants.PlayerTwoMarker, Constants.PlayerOneMarker },
                {Constants.PlayerTwoMarker, Constants.PlayerTwoMarker, Constants.PlayerOneMarker }
            };
            
            AssertWin(9, boardState);
        }

        private void AssertWin(int movesMade, char[,] boardState)
        {
            _boardService.Setup(x => x.MovesMade).Returns(movesMade);
            _boardService.Setup(x => x.BoardState).Returns(boardState);

            var sut = _resultService.CurrentState();

            Assert.That(sut, Is.EqualTo(GameState.Win));
        }
    }
}

