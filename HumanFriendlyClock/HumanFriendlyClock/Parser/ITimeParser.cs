namespace HumanFriendlyClock.Parser
{
    public interface ITimeParser
    {
        (int hour, int minute) Parse(string message);
    }
}