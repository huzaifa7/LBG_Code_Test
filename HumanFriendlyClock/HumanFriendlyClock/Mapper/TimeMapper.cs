using System.Collections.Generic;

namespace HumanFriendlyClock.Mapper
{
    public class TimeMapper : ITimeMapper
    {
        private readonly Dictionary<int, string> hourWordDictionary;
        private readonly Dictionary<int, string> minuteWordDictionary;

        public TimeMapper()
        {
            hourWordDictionary = new Dictionary<int, string>()
            {
                {01, "one"},
                {02, "two"},
                {03, "three"},
                {04, "four"},
                {05, "five"},
                {06, "six"},
                {07, "seven"},
                {08, "eight"},
                {09, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "one"},
                {14, "two"},
                {15, "three"},
                {16, "four"},
                {17, "five"},
                {18, "six"},
                {19, "seven"},
                {20, "eight"},
                {21, "nine"},
                {22, "ten"},
                {23, "eleven"},
                {24, "twelve"}
            };
            minuteWordDictionary = new Dictionary<int, string>()
            {
                {05, "five"},
                {10, "ten"},
                {15, "quarter"},
                {20, "twenty"},
                {25, "twenty five"},
                {30, "half"},
                {35, "twenty five"},
                {40, "twenty"},
                {45, "quarter"},
                {50, "ten"},
                {55, "five"}
            };
        }
        public string MapHour(int hour)
        {
            var translatedHour = hourWordDictionary[hour];

            return translatedHour;
        }

        public string MapMinute(int minute)
        {
            var translatedMinute = string.Empty;
            if (minute != 00)
            {
                translatedMinute = minuteWordDictionary[minute];
            }

            return translatedMinute;
        }
    }
}