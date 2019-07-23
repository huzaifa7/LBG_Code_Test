using System.Linq;
using TalkingClock.Mapper;
using TalkingClock.Parser;

namespace TalkingClock.Service
{
    public class TalkingClockService : ITalkingClockService
    {
        private readonly ITimeParser _timeParser;
        private readonly ITimeMapper _timeMapper;

        public TalkingClockService(ITimeParser timeParser, ITimeMapper timeMapper)
        {
            _timeParser = timeParser;
            _timeMapper = timeMapper;
        }
        public string Translate(string time)
        {
            var (hour, minute) = _timeParser.Parse(time);
            
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