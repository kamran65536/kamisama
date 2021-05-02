using NLog;
using NLog.LayoutRenderers;
using System;
using System.Globalization;
using System.Text;

namespace KamiSama.Extensions.NLog
{
    /// <summary>
    /// Persian Long Date Layout, same functionality as LongDate but using Persian Calender
    /// </summary>
	[LayoutRenderer("persian-longDate")]
	public class PersianLongDateLayoutRenderer : LayoutRenderer
	{
		private static readonly PersianCalendar persianCalendar = new();
        /// <summary>
        /// appends long date with persian date time into it
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="logEvent"></param>
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
            DateTime dt = logEvent.TimeStamp;
			//no culture according to specs

			builder.Append4DigitsZeroPadded(persianCalendar.GetYear(dt));
            builder.Append('-');
            builder.Append2DigitsZeroPadded(persianCalendar.GetMonth(dt));
            builder.Append('-');
            builder.Append2DigitsZeroPadded(persianCalendar.GetDayOfMonth(dt));
            builder.Append(' ');
            builder.Append2DigitsZeroPadded(dt.Hour);
            builder.Append(':');
            builder.Append2DigitsZeroPadded(dt.Minute);
            builder.Append(':');
            builder.Append2DigitsZeroPadded(dt.Second);
            builder.Append('.');
            builder.Append4DigitsZeroPadded((int)(dt.Ticks % 10000000) / 1000);
		}
	}
}
