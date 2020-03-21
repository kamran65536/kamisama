using System;
using System.Globalization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Persian DateTime Extensions
	/// </summary>
	public static class PersianDateTimeExtensions
	{
		private static DateTimeFormatInfo dateTimeFormatInfo;
		static PersianDateTimeExtensions()
		{
			var cultureInfo = new CultureInfo("fa-IR");
			var persianCalendar = new PersianCalendar();

			dateTimeFormatInfo = cultureInfo.DateTimeFormat.Clone() as DateTimeFormatInfo;

			dateTimeFormatInfo.Calendar = persianCalendar;
		}
		/// <summary>
		/// Returns string equivalant to Persian date time info
		/// </summary>
		/// <param name="dateTime">date time to be converted</param>
		/// <returns></returns>
		public static string ToPersianString(this DateTime dateTime)
			=> dateTime.ToString(dateTimeFormatInfo);
		/// <summary>
		/// Returns string equivalant to Persian date time info and format
		/// </summary>
		/// <param name="dateTime">date time to be converted</param>
		/// <param name="format">formatto be used</param>
		/// <returns></returns>
		public static string ToPersianString(this DateTime dateTime, string format)
			=> dateTime.ToString(format, dateTimeFormatInfo);
		/// <summary>
		/// Parses a strign as persian date time (using PersianCalendar default date time format info)
		/// </summary>
		/// <param name="str">string to be parsed as datetime</param>
		/// <returns></returns>
		public static DateTime ParsePersianString(this string str)
			=> DateTime.Parse(str, dateTimeFormatInfo);
		/// <summary>
		/// Parses a strign as persian date time as exact format (using PersianCalendar default date time format info)
		/// </summary>
		/// <param name="str">string to be parsed as datetime</param>
		/// <param name="format">formatting to be matched</param>
		/// <returns></returns>
		public static DateTime ParseExactFromPersianString(this string str, string format)
			=> DateTime.ParseExact(str, format, dateTimeFormatInfo);
		/// <summary>
		/// Parses a strign as persian date time (using PersianCalendar default date time format info)
		/// </summary>
		/// <param name="str">string to be parsed as datetime</param>
		/// <param name="dateTime">result date time</param>
		/// <returns>true if parsing is successful</returns>
		public static bool TryParseFromPersianString(this string str, out DateTime dateTime)
			=> DateTime.TryParse(str, dateTimeFormatInfo, DateTimeStyles.None, out dateTime);
		/// <summary>
		/// Parses a strign as persian date time as exact format (using PersianCalendar default date time format info)
		/// </summary>
		/// <param name="str">string to be parsed as datetime</param>
		/// <param name="format">formatting to be matched</param>
		/// <param name="dateTime">result date time</param>
		/// <returns>true if parsing is successful</returns>
		public static bool TryParseExactFromPersianString(this string str, string format, out DateTime dateTime)
			=> DateTime.TryParseExact(str, format, dateTimeFormatInfo, DateTimeStyles.None, out dateTime);
	}
}
