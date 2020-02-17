using System;

namespace BerlinClock.Abstraction
{
    public interface IClockBuilder
    {
        IBerlinClock BuildClocks(String inputTime);
    }
}
