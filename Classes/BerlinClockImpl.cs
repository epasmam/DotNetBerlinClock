using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl
    {
        private Int32 _timeInSeconds;

        private const string IncorrectArgumentErrorMessage = "inputTime parameter should contain correct time";

        private const Char Yellow = 'Y';
        private const Char Red = 'R';
        private const Char Empty = 'O';

        public BerlinClockImpl(string inputTime)
        {
            if (String.IsNullOrWhiteSpace(inputTime))
                throw new ArgumentNullException(nameof(inputTime), IncorrectArgumentErrorMessage);

            if (DateTime.TryParse(inputTime, out DateTime parsedInputTime) == false)
                throw new ArgumentException(nameof(inputTime), IncorrectArgumentErrorMessage);

            this._timeInSeconds = (Int32)parsedInputTime.TimeOfDay.TotalSeconds;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
