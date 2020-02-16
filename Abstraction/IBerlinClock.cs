using System;

namespace BerlinClock.Abstraction
{
    public interface IBerlinClock
    {
        Boolean Blinker { get; }
        Boolean[] FiveHoursBulbs { get; }
        Boolean[] HoursBulbs { get; }
        Boolean[] FiveMinutesBulbs { get; }
        Boolean[] MinutesBulbs { get; }
    }
}
