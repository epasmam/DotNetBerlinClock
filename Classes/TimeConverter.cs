using BerlinClock.Abstraction;
using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private IClockRenderer<String> _renderer;

        public TimeConverter(IClockRenderer<String> renderer)
        {
            _renderer = renderer;
        }

        public string ConvertTime(string aTime)
        {
            return _renderer.RenderClocks(new Classes.BerlinClockImpl(aTime));
        }
    }
}
