using System;
using System.Collections.Generic;
using BerlinClock.Abstraction;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl : IBerlinClock
    {

        private Time _timeToShow;

        public Boolean Blinker => (this._timeToShow.Seconds & 1) == 0;

        public IEnumerable<Boolean> FiveHoursBulbs => switchOnBulbLights(this._timeToShow.Hours / 5, 4);

        public IEnumerable<Boolean> HoursBulbs => switchOnBulbLights(this._timeToShow.Hours % 5, 4);

        public IEnumerable<Boolean> FiveMinutesBulbs => switchOnBulbLights(this._timeToShow.Minutes / 5, 11);

        public IEnumerable<Boolean> MinutesBulbs => switchOnBulbLights(this._timeToShow.Minutes % 5, 4);

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
            while ((turnOnBulbsNumber = turnOnBulbsNumber - 1) >= 0)
            {
                result[currentIndex++] = true;
            }
            return result;
        }
    }
}
