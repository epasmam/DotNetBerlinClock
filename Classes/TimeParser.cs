using System;
using System.Globalization;

using BerlinClock.Abstraction;

namespace BerlinClock.Classes
{
    public class TimeParser : ITimeParser
    {
        // the only non-parseable time.
        private const String Midnight2400 = "24:00:00";
        private const Int32 Midnight2400Int32 = 240000;
        private const String TimeFormat = "HH:mm:ss";

        public Time GetTimeFromString(string inputTime)
        {
            Time result =
                DateTime.TryParseExact(inputTime, TimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out DateTime parsedInputTime)
                ? new Time(parsedInputTime.Hour, parsedInputTime.Minute, parsedInputTime.Second)
                : inputTime != Midnight2400
                    ? Time.Incorrect
                    : Time.FromInt32(Midnight2400Int32);
            return result;
        }
    }
}
