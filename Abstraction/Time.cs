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
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public readonly Boolean IsIncorrect => this.Equals(Incorrect);

        public readonly static Time Incorrect = new Time(-1, -1, -1);

        public static Time FromInt(int timeInInt)
        {
            return new Time(timeInInt / 10000, timeInInt / 100 % 100, timeInInt % 100);
        }
    }
}
