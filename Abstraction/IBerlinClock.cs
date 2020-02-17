using System;
using System.Collections.Generic;

namespace BerlinClock.Abstraction
{
    public interface IBerlinClock
    {
        Boolean Blinker { get; }
        IEnumerable<Boolean> FiveHoursBulbs { get; }
        IEnumerable<Boolean> HoursBulbs { get; }
        IEnumerable<Boolean> FiveMinutesBulbs { get; }
        IEnumerable<Boolean> MinutesBulbs { get; }
    }
}
