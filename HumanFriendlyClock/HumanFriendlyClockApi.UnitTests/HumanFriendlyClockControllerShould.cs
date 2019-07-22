using HumanFriendlyClock.Service;
using HumanFriendlyClockApi.Controllers;
using Moq;
using Xunit;

namespace HumanFriendlyClockApi.UnitTests
{
    public class HumanFriendlyClockControllerShould
    {
        [Fact]
        public void Call_HumanFriendlyClockService_When_Handling_A_Message()
        {
            // Arrange
            var message = "13:00";
            var humanFriendlyClockServiceMock = new Mock<IHumanFriendlyClockService>();
            var humanFriendlyClockApi = new HumanFriendlyClockController(humanFriendlyClockServiceMock.Object);

            // Act
            humanFriendlyClockApi.Get(message);

            // Assert
            humanFriendlyClockServiceMock.Verify(service => service.Translate(message), Times.Once);
        }

        [Fact]
        public void Return_FriendlyClockMessage_When_Handling_A_Message()
        {
            // Arrange
            var message = "13:00";
            var humanFriendlyClockServiceMock = new Mock<IHumanFriendlyClockService>();
            humanFriendlyClockServiceMock.Setup(service => service.Translate(message)).Returns("One o'clock");
            var humanFriendlyClockApi = new HumanFriendlyClockController(humanFriendlyClockServiceMock.Object);

            // Act
            var response = humanFriendlyClockApi.Get(message);
            
            // Assert
            Assert.Equal("One o'clock", response.Value);
        }
    }
}
