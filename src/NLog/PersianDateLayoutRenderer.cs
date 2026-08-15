namespace KamiSama.Extensions.NLog;

/// <summary>
/// Renders an NLog event timestamp with a configurable Persian-calendar date and time format.
/// Use <see cref="Format"/> to select the output accepted by the Persian date formatting extensions.
/// </summary>
[LayoutRenderer("persian-date")]
public class PersianDateLayoutRenderer : LayoutRenderer
{
	/// <summary>
	/// Gets or sets the Persian date and time format used to render the event timestamp.
	/// The default format is <c>yyyy/MM/dd HH:mm:ss.fff</c>.
	/// </summary>
	[DefaultParameter]
	public string Format { get; set; }
	/// <summary>
	/// Initializes a renderer that uses the default <c>yyyy/MM/dd HH:mm:ss.fff</c> format.
	/// </summary>
	public PersianDateLayoutRenderer()
	{
		Format = "yyyy/MM/dd HH:mm:ss.fff"; 
	}
	/// <summary>
	/// Converts the event timestamp to the configured Persian-calendar format and appends it to the layout output.
	/// </summary>
	/// <param name="builder">The buffer that receives the rendered timestamp.</param>
	/// <param name="logEvent">The NLog event whose timestamp is rendered.</param>
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		=> builder.Append(logEvent.TimeStamp.ToPersianString(Format));
}
