namespace HumanFriendlyClock.Mapper
{
    public interface ITimeMapper
    {
        string MapHour(int hour);
        string MapMinute(int minutes);
    }
}