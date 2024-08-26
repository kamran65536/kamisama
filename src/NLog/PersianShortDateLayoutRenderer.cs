namespace KamiSama.Extensions.NLog;

/// <summary>
/// Persian Short Date Layout, same functionality as LongDate but using Persian Calender
/// </summary>
[LayoutRenderer("persian-shortDate")]
public class PersianShortDateLayoutRenderer : LayoutRenderer
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
	}
}
