namespace KamiSama.Extensions;

/// <summary>
/// Provides formatting and parsing extensions that use the Persian calendar and the <c>fa-IR</c> date-time format.
/// Use them when Persian-calendar text must be exchanged with <see cref="DateTime"/> values.
/// </summary>
public static class PersianDateTimeExtensions
{
	private static readonly DateTimeFormatInfo dateTimeFormatInfo;
	static PersianDateTimeExtensions()
	{
		var persianCalendar = new PersianCalendar();
		var cultureInfo = new CultureInfo("fa-IR");
		dateTimeFormatInfo = (cultureInfo.DateTimeFormat.Clone() as DateTimeFormatInfo)!;

		dateTimeFormatInfo.Calendar = persianCalendar;
	}
	/// <summary>
	/// Formats the date and time using the Persian calendar and the default <c>fa-IR</c> date-time format.
	/// </summary>
	/// <param name="dateTime">date time to be converted</param>
	/// <returns></returns>
	public static string ToPersianString(this DateTime dateTime)
		=> dateTime.ToString(dateTimeFormatInfo);
	/// <summary>
	/// Formats the date and time with the specified format string using the Persian calendar.
	/// </summary>
	/// <param name="dateTime">date time to be converted</param>
	/// <param name="format">format to be used</param>
	/// <returns></returns>
	public static string ToPersianString(this DateTime dateTime, string format)
		=> dateTime.ToString(format, dateTimeFormatInfo);
	/// <summary>
	/// Parses the string as a date and time using the Persian calendar's default format information.
	/// </summary>
	/// <param name="str">string to be parsed as datetime</param>
	/// <returns></returns>
	public static DateTime ParseAsPersianDateTime(this string str)
		=> DateTime.Parse(str, dateTimeFormatInfo);
	/// <summary>
	/// Parses the string as a Persian-calendar date and time that must match the specified format exactly.
	/// </summary>
	/// <param name="str">string to be parsed as datetime</param>
	/// <param name="format">formatting to be matched</param>
	/// <returns></returns>
	public static DateTime ParseExactAsPersianDateTime(this string str, string format)
		=> DateTime.ParseExact(str, format, dateTimeFormatInfo);
	/// <summary>
	/// Attempts to parse the string as a date and time using the Persian calendar's default format information.
	/// </summary>
	/// <param name="str">string to be parsed as datetime</param>
	/// <param name="dateTime">result date time</param>
	/// <returns>true if parsing is successful</returns>
	public static bool TryParseAsPersianDateTime(this string str, out DateTime dateTime)
		=> DateTime.TryParse(str, dateTimeFormatInfo, DateTimeStyles.None, out dateTime);
	/// <summary>
	/// Attempts to parse the string as a Persian-calendar date and time that exactly matches the specified format.
	/// </summary>
	/// <param name="str">string to be parsed as datetime</param>
	/// <param name="format">formatting to be matched</param>
	/// <param name="dateTime">result date time</param>
	/// <returns>true if parsing is successful</returns>
	public static bool TryParseExactAsPersianDateTime(this string str, string format, out DateTime dateTime)
		=> DateTime.TryParseExact(str, format, dateTimeFormatInfo, DateTimeStyles.None, out dateTime);
}
