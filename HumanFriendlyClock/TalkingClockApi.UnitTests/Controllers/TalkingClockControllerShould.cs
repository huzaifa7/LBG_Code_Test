using Moq;
using TalkingClock.Service;
using TalkingClockApi.Controllers;
using Xunit;

namespace TalkingClockApi.UnitTests.Controllers
{
    public class TalkingClockControllerShould
    {
        [Fact]
        public void Call_TalkingClockService_When_Handling_A_Message()
        {
            // Arrange
            var message = "13:00";
            var talkingClockServiceMock = new Mock<ITalkingClockService>();
            var talkingClockController = new TalkingClockController(talkingClockServiceMock.Object);

            // Act
            talkingClockController.Get(message);

            // Assert
            talkingClockServiceMock.Verify(service => service.Translate(message), Times.Once);
        }

        [Fact]
        public void Return_FriendlyClockMessage_When_Handling_A_Message()
        {
            // Arrange
            var message = "13:00";
            var talkingClockServiceMock = new Mock<ITalkingClockService>();
            talkingClockServiceMock.Setup(service => service.Translate(message)).Returns("One o'clock");
            var talkingClockController = new TalkingClockController(talkingClockServiceMock.Object);

            // Act
            var response = talkingClockController.Get(message);
            
            // Assert
            Assert.Equal("One o'clock", response.Value);
        }
    }
}
