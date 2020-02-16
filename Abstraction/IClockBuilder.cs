namespace BerlinClock.Abstraction
{
    public interface IClockBuilder
    {
        IBerlinClock BuildClocks(string inputTime);
    }
}
