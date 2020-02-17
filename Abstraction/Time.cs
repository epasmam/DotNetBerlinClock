using System;

namespace BerlinClock.Abstraction
{
    public struct Time
    {
        public readonly Int32 Hours;
        public readonly Int32 Minutes;
        public readonly Int32 Seconds;

        public Time(Int32 hours, Int32 minutes, Int32 seconds)
        {
            if (hours >= 24 && (minutes != 00 || seconds != 00)
                || minutes > 59
                || seconds > 59)
            {
                this = Time.Incorrect;
            }
            else
            {
                this.Hours = hours;
                this.Minutes = minutes;
                this.Seconds = seconds;
            }
        }

        public readonly Boolean IsIncorrect => this.Equals(Incorrect);

        public readonly static Time Incorrect = new Time(-1, -1, -1);

        public static Time FromInt32(Int32 timeInInt32)
        {
            if (timeInInt32 < 0)
                return Time.Incorrect;

            Int32 hours = timeInInt32 / 10000;
            Int32 minutes = timeInInt32 / 100 % 100;
            Int32 seconds = timeInInt32 % 100;

            return new Time(hours, minutes, seconds);
        }
    }
}
