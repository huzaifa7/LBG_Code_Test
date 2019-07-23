using System.Collections.Generic;

namespace TalkingClock.Mapper
{
    public class TimeMapper : ITimeMapper
    {
        private readonly Dictionary<int, string> hourWordDictionary;
        private readonly Dictionary<string, string> singleDigitMinuteWordDictionary;
        private Dictionary<string, string> doubleDigitMinuteWordDictionary;

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
            singleDigitMinuteWordDictionary = new Dictionary<string, string>()
            {
                {"1", "one"},
                {"2", "two"},
                {"3", "three"},
                {"4", "four"},
                {"5", "five"},
                {"6", "six"},
                {"7", "seven"},
                {"8", "eight"},
                {"9", "nine"},
            };

            doubleDigitMinuteWordDictionary = new Dictionary<string, string>()
            {
                {"10", "ten"},
                {"11", "eleven"},
                {"12", "twelve"},
                {"13", "thirteen"},
                {"14", "fourteen"},
                {"15", "quarter"},
                {"16", "sixteen"},
                {"17", "seventeen"},
                {"18", "eighteen"},
                {"19", "nineteen"},
                {"20", "twenty"},
                {"30", "half"}
            };
        }
        public string MapHour(int hour)
        {
            var translatedHour = hourWordDictionary[hour];

            return translatedHour;
        }

        public string MapMinute(int minutes)
        {
            if (minutes == 00)
            {
                return string.Empty;
            }
            var inversedMinutes = InverseMinutes(minutes).ToString();

            if (inversedMinutes.Length == 1)
            {
                return singleDigitMinuteWordDictionary[inversedMinutes];
            }
            
            if (doubleDigitMinuteWordDictionary.TryGetValue(inversedMinutes, out string translatedMinute))
            {
                return translatedMinute;
            }

            var doubleDigitValue = RoundToTheLowestTenValue(inversedMinutes);
            var singleDigitValue = inversedMinutes.Substring(1);
            var firstWord = doubleDigitMinuteWordDictionary[doubleDigitValue];
            var secondWord = singleDigitMinuteWordDictionary[singleDigitValue];

            return $"{firstWord} {secondWord}";
        }

        private static string RoundToTheLowestTenValue(string inversedMinutes)
        {
            return inversedMinutes.Substring(0,1) + "0";
        }

        private int InverseMinutes(int minute)
        {
            if (minute > 30)
            {
                return 60 - minute;
            }

            return minute;
        }
    }
}