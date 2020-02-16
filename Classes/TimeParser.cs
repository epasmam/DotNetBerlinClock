using BerlinClock.Abstraction;
using System;
using System.Globalization;

namespace BerlinClock.Classes
{
    public class TimeParser : ITimeParser
    {
        // the only non-parseable time.
        private const String Midnight2400 = "24:00:00";
        private const String TimeFormat = "HH:mm:ss";

        public Time GetTimeFromString(string inputTime)
        {
            Time result =
                DateTime.TryParseExact(inputTime, TimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out DateTime parsedInputTime)
                ? new Time(parsedInputTime.Hour, parsedInputTime.Minute, parsedInputTime.Second)
                : inputTime != Midnight2400
                    ? Time.Incorrect
                    : new Time(24, 0, 0);
            return result;
        }
    }
}
