namespace TalkingClock.Parser
{
    public interface ITimeParser
    {
        (int hour, int minutes) Parse(string message);
    }
}