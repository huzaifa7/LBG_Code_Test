using System;
using HumanFriendlyClock.Mapper;
using HumanFriendlyClock.Parser;
using HumanFriendlyClock.Service;

namespace HumanFriendlyClock
{
    class Program
    {
        private static HumanFriendlyClockService _humanFriendlyClockService;

        static void Main(string[] args)
        {
            SetupDependencies();
            
            while (true)
            {
                Console.WriteLine("Enter new time in following format {HH:mm} or press 'Enter' for current time");
                var input = Console.ReadLine();
                var time = string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                {
                    time = DateTime.UtcNow.ToString("HH:mm");
                }
                var output = _humanFriendlyClockService.Translate(time);
                Console.WriteLine(output);
            }
        }

        private static void SetupDependencies()
        {
            var timeParser = new TimeParser();
            var timeMapper = new TimeMapper();
            _humanFriendlyClockService = new HumanFriendlyClockService(timeParser, timeMapper);
        }
    }
}
