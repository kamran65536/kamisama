namespace KamiSama.Extensions.NLog;

/// <summary>
/// Renders the date portion of an NLog event timestamp using the Persian calendar.
/// The fixed output format is <c>yyyy-MM-dd</c>.
/// </summary>
[LayoutRenderer("persian-shortDate")]
public class PersianShortDateLayoutRenderer : LayoutRenderer
{
	private static readonly PersianCalendar persianCalendar = new();
	/// <summary>
	/// Appends the event timestamp in the fixed Persian-calendar short-date format.
	/// </summary>
	/// <param name="builder">The buffer that receives the rendered date.</param>
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
	}
}
