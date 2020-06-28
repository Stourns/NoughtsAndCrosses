using Moq;
using NoughtsAndCrosses.Enums;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Services;
using NUnit.Framework;

namespace NoughtsAndCrossesTests.Services
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<ITurnService> _turnService;
        private Mock<IBoardService> _boardService;

        private IGameService _gameService;

        [SetUp]
        public void Setup()
        {
            _turnService = new Mock<ITurnService>();
            _boardService = new Mock<IBoardService>();

            _gameService = new GameService(_turnService.Object, _boardService.Object);
        }

        [TestCase(GameState.Win)]
        [TestCase(GameState.Draw)]
        public void Play_GivenGameWinOrDraw_ReturnsTrue(GameState gameState)
        {
            _turnService.Setup(x => x.TakeTurn(It.IsAny<char>())).Returns(gameState);

            var sut = _gameService.Play();

            Assert.That(sut, Is.True);
        }
    }
}
