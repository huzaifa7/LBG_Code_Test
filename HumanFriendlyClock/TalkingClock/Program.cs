using System;
using TalkingClock.Mapper;
using TalkingClock.Parser;
using TalkingClock.Service;

namespace TalkingClock
{
    class Program
    {
        private static TalkingClockService _talkingClockService;

        static void Main(string[] args)
        {
            SetupDependencies();
            
            while (true)
            {
                Console.WriteLine("Enter new time in following format {HH:mm} or press 'Enter' for current time");
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(_talkingClockService.Translate(input));
                }
                else
                {
                    Console.WriteLine(_talkingClockService.Translate(DateTime.UtcNow.ToString("HH:mm")));
                }
            }
        }

        private static void SetupDependencies()
        {
            var timeParser = new TimeParser();
            var timeMapper = new TimeMapper();
            _talkingClockService = new TalkingClockService(timeParser, timeMapper);
        }
    }
}
