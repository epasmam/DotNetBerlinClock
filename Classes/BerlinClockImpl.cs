using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockImpl
    {
        private Int32 _seconds;
        private Int32 _minutes;
        private Int32 _hours;

        private const string IncorrectArgumentErrorMessage = "inputTime parameter should contain correct time";
        // the only non-parseable time.
        private const string Midnight2400 = "24:00:00";

        private const Char Yellow = 'Y';
        private const Char Red = 'R';
        private const Char Empty = 'O';

        public Boolean Blinker
        {
            get
            {
                return (this._seconds & 1) == 0;
            }
        }

        public Boolean[] Fivers
        {
            get
            {
                var fivers = new Boolean[4];
                int currentIndex = 0;
                int currentTime = this._hours / 5;
                while((currentTime = currentTime - 1) >= 0)
                {
                    fivers[currentIndex++] = true;
                }
                return fivers;
            }
        }

        public Boolean[] Hours
        {
            get
            {
                var hours = new Boolean[4];

                int currentIndex = 0;
                int currentTime = this._hours % 5;
                while((currentTime = currentTime - 1) >= 0)
                {
                    hours[currentIndex++] = true;
                }

                return hours;
            }
        }

        public Boolean[] MinutesFivers
        {
            get
            {
                var minutesFivers = new Boolean[11];

                int currentIndex = 0;
                int currentTime = this._minutes / 5;
                while((currentTime = currentTime - 1) >= 0)
                {
                    minutesFivers[currentIndex++] = true;
                }

                return minutesFivers;
            }
        }

        public Boolean[] Minutes
        {
            get
            {
                var minutes = new Boolean[4];
                int currentIndex = 0;
                int currentTime = this._minutes % 5;
                while ((currentTime = currentTime - 1) >= 0)
                {
                    minutes[currentIndex++] = true;
                }

                return minutes;
            }
        }

        public BerlinClockImpl(string inputTime)
        {
            if (String.IsNullOrWhiteSpace(inputTime))
                throw new ArgumentNullException(nameof(inputTime), IncorrectArgumentErrorMessage);

            if (DateTime.TryParseExact(inputTime, "HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out DateTime parsedInputTime) == false)
            {
                if (inputTime != Midnight2400)
                    throw new ArgumentException(nameof(inputTime), IncorrectArgumentErrorMessage);
                else
                {
                    _hours = 24;
                    _minutes = 0;
                    _seconds = 0;
                }
            }
            else
            {
                _seconds = parsedInputTime.Second;
                _minutes = parsedInputTime.Minute;
                _hours = parsedInputTime.Hour;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("{0}", Blinker ? Yellow : Empty));
            sb.AppendLine(String.Join("", Fivers.Select(f => f ? Red : Empty)));
            sb.AppendLine(String.Join("", Hours.Select(h => h ? Red : Empty)));
            int i = 0;
            sb.AppendLine(String.Join("", MinutesFivers.Select(v => v ? (++i % 3 == 0 ? Red : Yellow) : Empty)));
            sb.Append(String.Join("", Minutes.Select(m => m ? Yellow: Empty)));
            return sb.ToString();
        }
    }
}
