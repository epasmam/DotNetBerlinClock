namespace BerlinClock.Abstraction
{
    public interface IClockRenderer<T>
    {
        T RenderClocks(IBerlinClock clock);
    }
}
