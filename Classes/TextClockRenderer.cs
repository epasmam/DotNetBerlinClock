using System;
using System.Linq;
using System.Text;

using BerlinClock.Abstraction;

namespace BerlinClock.Classes
{
    public class TextClockRenderer : IClockRenderer<String>
    {

        private const Char Yellow = 'Y';
        private const Char Red = 'R';
        private const Char Empty = 'O';

        public string RenderClocks(IBerlinClock clock)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(String.Format("{0}{1}", clock.Blinker ? Yellow : Empty, Environment.NewLine));
            sb.AppendLine(String.Join("", clock.FiveHoursBulbs.Select(f => f ? Red : Empty)));
            sb.AppendLine(String.Join("", clock.HoursBulbs.Select(h => h ? Red : Empty)));
            int i = 0;
            sb.AppendLine(String.Join("", clock.FiveMinutesBulbs.Select(v => v ? (++i % 3 == 0 ? Red : Yellow) : Empty)));
            sb.Append(String.Join("", clock.MinutesBulbs.Select(m => m ? Yellow : Empty)));
            return sb.ToString();
        }
    }
}
