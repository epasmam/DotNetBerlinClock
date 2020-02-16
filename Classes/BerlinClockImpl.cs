using System;
using System.Globalization;

using BerlinClock.Abstraction;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl : IBerlinClock
    {
        private Int32 _seconds;
        private Int32 _minutes;
        private Int32 _hours;

        private const string IncorrectArgumentErrorMessage = "inputTime parameter should contain correct time";
        // the only non-parseable time.
        private const string Midnight2400 = "24:00:00";
        private const string TimeFormat = "HH:mm:ss";

        private Boolean[] intToBooleanBulb(int currentTime, int bulbsCount)
        {
            var result = new Boolean[bulbsCount];
            int currentIndex = 0;
            while((currentTime = currentTime - 1) >= 0)
            {
                result[currentIndex++] = true;
            }
            return result;
        }

        public Boolean Blinker => (this._seconds & 1) == 0;

        public Boolean[] FiveHoursBulbs => intToBooleanBulb(this._hours / 5, 4);

        public Boolean[] HoursBulbs => intToBooleanBulb(this._hours % 5, 4);

        public Boolean[] FiveMinutesBulbs => intToBooleanBulb(this._minutes / 5, 11);

        public Boolean[] MinutesBulbs => intToBooleanBulb(this._minutes % 5, 4);

        public BerlinClockImpl(string inputTime)
        {
            if (String.IsNullOrWhiteSpace(inputTime))
                throw new ArgumentNullException(nameof(inputTime), IncorrectArgumentErrorMessage);

            if (DateTime.TryParseExact(inputTime, TimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out DateTime parsedInputTime) == false)
            {
                if (inputTime != Midnight2400)
                    throw new ArgumentException(nameof(inputTime), IncorrectArgumentErrorMessage);
                else
                    _hours = 24;
            }
            else
            {
                _seconds = parsedInputTime.Second;
                _minutes = parsedInputTime.Minute;
                _hours = parsedInputTime.Hour;
            }
        }
    }
}
