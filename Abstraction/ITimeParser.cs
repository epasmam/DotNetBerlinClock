using System;

namespace BerlinClock.Abstraction
{
    public interface ITimeParser
    {
        Time GetTimeFromString(String inputTime);
    }
}
