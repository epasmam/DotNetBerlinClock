namespace BerlinClock.Abstraction
{
    public interface ITimeParser
    {
        Time GetTimeFromString(string inputTime);
    }
}
