using System;
using System.Collections.Generic;
using BerlinClock.Abstraction;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl : IBerlinClock
    {
        private const Int32 BulbsInTopRow = 4;
        private const Int32 BulbsInSecondRow = 4;
        private const Int32 BulbsInThirdRow = 11;
        private const Int32 BulbsInFourthRow = 4;
        private const Int32 ClockDivisor = 5;

        private Time _timeToShow;

        public Boolean Blinker => (this._timeToShow.Seconds & 1) == 0;

        public IEnumerable<Boolean> FiveHoursBulbs => switchOnBulbLights(this._timeToShow.Hours / ClockDivisor, BulbsInTopRow);

        public IEnumerable<Boolean> HoursBulbs => switchOnBulbLights(this._timeToShow.Hours % ClockDivisor, BulbsInSecondRow);

        public IEnumerable<Boolean> FiveMinutesBulbs => switchOnBulbLights(this._timeToShow.Minutes / ClockDivisor, BulbsInThirdRow);

        public IEnumerable<Boolean> MinutesBulbs => switchOnBulbLights(this._timeToShow.Minutes % ClockDivisor, BulbsInFourthRow);

        public BerlinClockImpl(Time timeToShow)
        {
            if (timeToShow.IsIncorrect)
                throw new ArgumentException(nameof(timeToShow));
            this._timeToShow = timeToShow;
        }

        private IEnumerable<Boolean> switchOnBulbLights(Int32 turnOnBulbsNumber, Int32 bulbsCount)
        {
            var result = new Boolean[bulbsCount];
            int currentIndex = 0;
            while (--turnOnBulbsNumber >= 0)
            {
                result[currentIndex++] = true;
            }
            return result;
        }
    }
}
