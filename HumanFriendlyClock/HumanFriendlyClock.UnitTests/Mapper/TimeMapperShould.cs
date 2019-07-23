using System;
using HumanFriendlyClock.Mapper;
using Xunit;

namespace HumanFriendlyClock.UnitTests.Mapper
{
    public class TimeMapperShould
    {
        private readonly TimeMapper _timeMapper;

        public TimeMapperShould()
        {
            _timeMapper = new TimeMapper();
        }

        [Theory]
        [InlineData(01, "one")]
        [InlineData(02, "two")]
        [InlineData(03, "three")]
        [InlineData(04, "four")]
        [InlineData(05, "five")]
        [InlineData(06, "six")]
        [InlineData(07, "seven")]
        [InlineData(08, "eight")]
        [InlineData(09, "nine")]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(12, "twelve")]
        [InlineData(13, "one")]
        [InlineData(14, "two")]
        [InlineData(15, "three")]
        [InlineData(16, "four")]
        [InlineData(17, "five")]
        [InlineData(18, "six")]
        [InlineData(19, "seven")]
        [InlineData(20, "eight")]
        [InlineData(21, "nine")]
        [InlineData(22, "ten")]
        [InlineData(23, "eleven")]
        [InlineData(24, "twelve")]
        public void Return_Hour_As_Word_When_An_Hour_Value_Is_Passed(int hour, string expectedHourInWord)
        {
            // Act
            var hourInWord = _timeMapper.MapHour(hour);

            // Assert
            Assert.Equal(expectedHourInWord, hourInWord);
        }

        [Fact]
        public void Retun_Empty_String_When_00_Minute_Is_Passed()
        {
            // Arrange
            var minute = 00;

            // Act
            var minuteInWord = _timeMapper.MapMinute(minute);

            // Assert
            Assert.Equal(string.Empty, minuteInWord);
        }

        [Theory]
        [InlineData(05, "five")]
        [InlineData(10, "ten")]
        [InlineData(15, "quarter")]
        [InlineData(22, "twenty two")]
        [InlineData(25, "twenty five")]
        [InlineData(30, "half")]
        [InlineData(35, "twenty five")]
        [InlineData(40, "twenty")]
        [InlineData(45, "quarter")]
        [InlineData(50, "ten")]
        [InlineData(55, "five")]
        public void Return_Minute_As_Word_When_A_Minute_Value_Is_Passed(int minute, string expectedMinuteInWord)
        {
            // Act
            var minutesInWord = _timeMapper.MapMinute(minute);

            // Assert
            Assert.Equal(expectedMinuteInWord, minutesInWord);
        }
    }
}
