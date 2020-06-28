using Moq;
using NoughtsAndCrosses.Interfaces;
using NoughtsAndCrosses.Services;
using NUnit.Framework;

namespace NoughtsAndCrossesTests.Services
{
    [TestFixture]
    class InputServiceTests
    {
        private Mock<IBoardService> _boardService;
        private IInputService _inputService;

        [SetUp]
        public void Setup()
        {
            _boardService = new Mock<IBoardService>();
            _inputService = new InputService(_boardService.Object);
        }

        [TestCase("0", ExpectedResult = false)]
        [TestCase("a", ExpectedResult = false)]
        [TestCase("!", ExpectedResult = false)]
        [TestCase("ghh", ExpectedResult = false)]
        [TestCase("    dfss dfdsf   ", ExpectedResult = false)]
        [TestCase("1236784", ExpectedResult = false)]
        [TestCase("     1", ExpectedResult = false)]
        [TestCase("     asdd!!! asd////", ExpectedResult = false)]
        public bool HandleInput_GivenInputNotAnInteger_ReturnsFalse(string input)
        {
            return _inputService.HandleInput(input, 'X');
        }

        [TestCase("1", ExpectedResult = true)]
        [TestCase("2", ExpectedResult = true)]
        [TestCase("3", ExpectedResult = true)]
        [TestCase("4", ExpectedResult = true)]
        [TestCase("5", ExpectedResult = true)]
        [TestCase("6", ExpectedResult = true)]
        [TestCase("7", ExpectedResult = true)]
        [TestCase("8", ExpectedResult = true)]
        [TestCase("9", ExpectedResult = true)]
        public bool HandleInput_GivenInputValid_ReturnsTrue(string input)
        {
            _boardService.Setup(x => x.ValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            return _inputService.HandleInput(input, 'X');
        }

        [TestCase("1", ExpectedResult = false)]
        [TestCase("2", ExpectedResult = false)]
        [TestCase("3", ExpectedResult = false)]
        [TestCase("4", ExpectedResult = false)]
        [TestCase("5", ExpectedResult = false)]
        [TestCase("6", ExpectedResult = false)]
        [TestCase("7", ExpectedResult = false)]
        [TestCase("8", ExpectedResult = false)]
        [TestCase("9", ExpectedResult = false)]
        public bool HandleInput_GivenInputValidButPositionTake_ReturnsFalse(string input)
        {
            _boardService.Setup(x => x.ValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            return _inputService.HandleInput(input, 'X');
        }
    }
}
