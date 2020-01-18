using System;
using System.Globalization;

namespace KamiSama.Extensions
{
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

		public static string ToPersianString(this DateTime dateTime)
			=> dateTime.ToString(dateTimeFormatInfo);

		public static string ToPersianString(this DateTime dateTime, string format)
			=> dateTime.ToString(format, dateTimeFormatInfo);
	}
}
