using BerlinClock.Abstraction;
using System;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private const string RendererNotProvidedErrorMessage = "Renderer should be provided";
        private const string BuilderNotProvidedErrorMessage = "Builder should be provided";

        private IClockRenderer<String> _renderer;
        private IClockBuilder _builder;

        public TimeConverter(IClockRenderer<String> renderer, IClockBuilder builder)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer), RendererNotProvidedErrorMessage);
            if (builder == null)
                throw new ArgumentNullException(nameof(builder), BuilderNotProvidedErrorMessage);
            this._renderer = renderer;
            this._builder = builder;
        }

        public string ConvertTime(string aTime)
        {
            IBerlinClock clock = this._builder.BuildClocks(aTime);
            return _renderer.RenderClocks(clock);
        }
    }
}
