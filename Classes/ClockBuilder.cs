using BerlinClock.Abstraction;
using System;

namespace BerlinClock.Classes
{
    public class ClockBuilder : IClockBuilder
    {
        private const String IncorrectParserErrorMessage = "No parser to parse input time provided";

        private const String IncorrectArgumentErrorMessage = "inputTime parameter should contain correct time";

        private ITimeParser _timeParser;

        public ClockBuilder(ITimeParser timeParser)
        {
            if (timeParser == null)
                throw new ArgumentNullException(nameof(timeParser), IncorrectParserErrorMessage);
            this._timeParser = timeParser;
        }

        public IBerlinClock BuildClocks(String inputTime)
        {
            if (String.IsNullOrWhiteSpace(inputTime))
                throw new ArgumentNullException(nameof(inputTime), IncorrectArgumentErrorMessage);

            Time timeToShow = this._timeParser.GetTimeFromString(inputTime);
            if (timeToShow.IsIncorrect)
                throw new ArgumentException(IncorrectArgumentErrorMessage, nameof(inputTime));

            return new BerlinClockImpl(timeToShow);
        }
    }
}
