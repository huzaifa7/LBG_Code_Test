using System.Linq;
using HumanFriendlyClock.Mapper;
using HumanFriendlyClock.Parser;

namespace HumanFriendlyClock.Service
{
    public class HumanFriendlyClockService : IHumanFriendlyClockService
    {
        private readonly ITimeParser _timeParser;
        private readonly ITimeMapper _timeMapper;

        public HumanFriendlyClockService(ITimeParser timeParser, ITimeMapper timeMapper)
        {
            _timeParser = timeParser;
            _timeMapper = timeMapper;
        }
        public string Translate(string message)
        {
            var (hour, minute) = _timeParser.Parse(message);
            
            var translatedHour = _timeMapper.MapHour(hour);
            var translatedMinute = _timeMapper.MapMinute(minute);
            if (MinutesAreZero(minute))
            {
                return Format($"{translatedHour} o'clock");
            }
            
            if (MinuteIsLessThanThirty(minute))
            {
                return Format($"{translatedMinute} past {translatedHour}");
            }

            translatedHour = GetNewHourWhenMinuteIsGreaterThanThirty(hour);
            return Format($"{translatedMinute} to {translatedHour}");
        }

        private string GetNewHourWhenMinuteIsGreaterThanThirty(int hour)
        {
            return _timeMapper.MapHour(hour+1);
        }

        private static bool MinuteIsLessThanThirty(int minute)
        {
            return minute <= 30;
        }

        private static bool MinutesAreZero(int minute)
        {
            return minute == 00;
        }

        private static string Format(string message)
        {
            return $"{message.First().ToString().ToUpper() + message.Substring(1)}";
        }
    }
}