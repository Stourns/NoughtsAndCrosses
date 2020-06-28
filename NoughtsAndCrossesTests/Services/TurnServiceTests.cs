using Moq;
using NoughtsAndCrosses.Enums;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Services;
using NUnit.Framework;

namespace NoughtsAndCrossesTests.Services
{
    [TestFixture]
    public class TurnServiceTests
    {
        private Mock<IInputService> _inputService;
        private Mock<IResultService> _resultService;
        private Mock<IConsoleWrapper> _consoleWrapper;
        private ITurnService _turnService;

        [SetUp]
        public void Setup()
        {
            _inputService = new Mock<IInputService>();
            _resultService = new Mock<IResultService>();
            _consoleWrapper = new Mock<IConsoleWrapper>();
            _turnService = new TurnService(_inputService.Object, _resultService.Object, _consoleWrapper.Object);
        }

        [Test]
        public void TakeTurn_GivenGameStateInProgress_ReturnsGameStateInProgress()
        {
            _consoleWrapper.Setup(x => x.ReadLine()).Returns(It.IsAny<string>());
            _inputService.Setup(x => x.HandleInput(It.IsAny<string>(), It.IsAny<char>())).Returns(true);
            _resultService.Setup(x => x.CurrentState()).Returns(GameState.InProgress);
            

            var sut = _turnService.TakeTurn('X');

            Assert.That(sut, Is.EqualTo(GameState.InProgress));
        }

        [Test]
        public void TakeTurn_GivenGameStateWin_ReturnsGameStateWin()
        {
            _consoleWrapper.Setup(x => x.ReadLine()).Returns(It.IsAny<string>());
            _inputService.Setup(x => x.HandleInput(It.IsAny<string>(), It.IsAny<char>())).Returns(true);
            _resultService.Setup(x => x.CurrentState()).Returns(GameState.Win);

            var sut = _turnService.TakeTurn('X');

            Assert.That(sut, Is.EqualTo(GameState.Win));
        }

        [Test]
        public void TakeTurn_GivenGameStateDraw_ReturnsGameStateDraw()
        {
            _consoleWrapper.Setup(x => x.ReadLine()).Returns(It.IsAny<string>());
            _inputService.Setup(x => x.HandleInput(It.IsAny<string>(), It.IsAny<char>())).Returns(true);
            _resultService.Setup(x => x.CurrentState()).Returns(GameState.Draw);

            var sut = _turnService.TakeTurn('X');

            Assert.That(sut, Is.EqualTo(GameState.Draw));
        }
    }
}
