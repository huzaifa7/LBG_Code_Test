using Moq;
using TalkingClock.Mapper;
using TalkingClock.Parser;
using TalkingClock.Service;
using Xunit;

namespace TalkingClock.UnitTests.Service
{
    public class TalkingClockServiceShould
    {
        private readonly Mock<ITimeParser> _timeParserMock;
        private readonly Mock<ITimeMapper> _timeMapperMock;
        private readonly string _inputMessage;
        private readonly ITalkingClockService _talkingClockService;

        public TalkingClockServiceShould()
        {
            _inputMessage = "01:00";
            _timeParserMock = new Mock<ITimeParser>();
            _timeParserMock.Setup(parser => parser.Parse(It.IsAny<string>())).Returns((01, 00));
            _timeMapperMock = new Mock<ITimeMapper>();
            _timeMapperMock.Setup(mapper => mapper.MapHour(01)).Returns("one");
            _timeMapperMock.Setup(mapper => mapper.MapMinute(00)).Returns(string.Empty);
            _talkingClockService = new TalkingClockService(_timeParserMock.Object, _timeMapperMock.Object);
        }

        [Fact]
        public void Call_TimeParser_When_Translating_Message()
        {
            // Act
            _talkingClockService.Translate(_inputMessage);

            // Assert
            _timeParserMock.Verify(parser => parser.Parse(_inputMessage), Times.Once);
        }

        [Fact]
        public void Call_TimeMapper_When_Translating_Message()
        {
            // Act
            _talkingClockService.Translate(_inputMessage);

            // Assert
            _timeMapperMock.Verify(parser => parser.MapHour(01), Times.Once);
            _timeMapperMock.Verify(parser => parser.MapMinute(00), Times.Once);

        }

        [Fact]
        public void Convert_0100_String_To_Human_Friendly_Text()
        {
            // Arrange
            var timeAsString = "01:00";
            var expectedFriendlyMessage = "One o'clock";

            // Act
            var timeMessage = _talkingClockService.Translate(timeAsString);

            // Assert
            Assert.Equal(expectedFriendlyMessage, timeMessage);
        }

        [Fact]
        public void Convert_1530_String_To_Human_Friendly_Text()
        {
            // Arrange
            var timeAsString = "15:30";
            var expectedFriendlyMessage = "Half past three";
            _timeParserMock.Setup(parser => parser.Parse(timeAsString)).Returns((15, 30));
            _timeMapperMock.Setup(mapper => mapper.MapHour(15)).Returns("three");
            _timeMapperMock.Setup(mapper => mapper.MapMinute(30)).Returns("half");

            // Act
            var timeMessage = _talkingClockService.Translate(timeAsString);

            // Assert
            Assert.Equal(expectedFriendlyMessage, timeMessage);
        }
        
        [Fact]
        public void Convert_1655_String_To_Human_Friendly_Text()
        {
            // Arrange
            var timeAsString = "16:55";
            var expectedFriendlyMessage = "Five to five";
            _timeParserMock.Setup(parser => parser.Parse(timeAsString)).Returns((16, 55));
            _timeMapperMock.Setup(mapper => mapper.MapHour(16)).Returns("four");
            _timeMapperMock.Setup(mapper => mapper.MapHour(17)).Returns("five");
            _timeMapperMock.Setup(mapper => mapper.MapMinute(55)).Returns("five");

            // Act
            var timeMessage = _talkingClockService.Translate(timeAsString);

            // Assert
            Assert.Equal(expectedFriendlyMessage, timeMessage);
        }
    }
}
