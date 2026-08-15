namespace KamiSama.Extensions.NLog;

/// <summary>
/// Renders an NLog event timestamp as a Persian-calendar date with time and four fractional-second digits.
/// The fixed output format is <c>yyyy-MM-dd HH:mm:ss.ffff</c>.
/// </summary>
[LayoutRenderer("persian-longDate")]
public class PersianLongDateLayoutRenderer : LayoutRenderer
{
	private static readonly PersianCalendar persianCalendar = new();
	/// <summary>
	/// Appends the event timestamp in the fixed Persian-calendar long-date format.
	/// </summary>
	/// <param name="builder">The buffer that receives the rendered timestamp.</param>
	/// <param name="logEvent">The NLog event whose timestamp is rendered.</param>
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
