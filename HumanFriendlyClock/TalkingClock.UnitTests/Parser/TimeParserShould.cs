﻿using TalkingClock.Parser;
using Xunit;

namespace TalkingClock.UnitTests.Parser
{
    public class TimeParserShould
    {
        private readonly TimeParser _timeParser;

        public TimeParserShould()
        {
            _timeParser = new TimeParser();
        }
        [Fact]
        public void Return_Hour_And_Minute_When_Time_Is_Passed_In_As_String()
        {
            // Arrange
            var timeAsString = "01:00";

            // Act
            var (hour, minute) = _timeParser.Parse(timeAsString);

            // Assert
            Assert.Equal(1, hour);
            Assert.Equal(00, minute);
        }

        [Fact]
        public void Return_Hour_And_Minute_When_Time_Is_Passed_In_An_Arbitrary_Text()
        {
            // Arrange
            var timeInArbitraryText = "The time is 15:30";

            // Act
            var (hour, minute) = _timeParser.Parse(timeInArbitraryText);

            // Assert
            Assert.Equal(15, hour);
            Assert.Equal(30, minute);
        }
    }
}
