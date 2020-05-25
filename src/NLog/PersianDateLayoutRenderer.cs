using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using System.Text;

namespace KamiSama.Extensions.NLog
{
	/// <summary>
	/// Persian Date Layout Renderer
	/// </summary>
	[LayoutRenderer("persian-date")]
	public class PersianDateLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Date Time format, default is yyyy/MM/dd HH:mm:ss.fff
		/// </summary>
		[DefaultParameter]
		public string Format { get; set; }
		/// <summary>
		/// constructor
		/// </summary>
		public PersianDateLayoutRenderer()
		{
			Format = "yyyy/MM/dd HH:mm:ss.fff"; 
		}
		/// <summary>
		/// Appends the date string to the log message
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="logEvent"></param>
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
			=> builder.Append(logEvent.TimeStamp.ToPersianString(Format));
	}
}
