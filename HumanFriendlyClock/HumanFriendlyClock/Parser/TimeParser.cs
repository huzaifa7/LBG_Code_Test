﻿using System.Text.RegularExpressions;

namespace HumanFriendlyClock.Parser
{
    public class TimeParser : ITimeParser
    {
        public (int hour, int minute) Parse(string message)
        {
            var time = Regex.Match(message, @"\d{2}:\d{2}").Value;
            var timeArray = time.Split(':');
            var hour = int.Parse(timeArray[0]);
            var minute = int.Parse(timeArray[1]);
            return (hour, minute);
        }
    }
}