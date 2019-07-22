using System;
using HumanFriendlyClock.Mapper;
using HumanFriendlyClock.Parser;
using HumanFriendlyClock.Service;

namespace HumanFriendlyClock
{
    class Program
    {
        private static HumanFriendlyClockService _humansFriendlyClockService;

        static void Main(string[] args)
        {
            SetupDependencies();
            
            while (true)
            {
                Console.WriteLine("Enter new time in following format {HH:mm}");
                var inputMessage = Console.ReadLine();

                var output = _humansFriendlyClockService.Translate(inputMessage);
                Console.WriteLine(output);
            }
        }

        private static void SetupDependencies()
        {
            var timeParser = new TimeParser();
            var timeMapper = new TimeMapper();
            _humansFriendlyClockService = new HumanFriendlyClockService(timeParser, timeMapper);
        }
    }
}
