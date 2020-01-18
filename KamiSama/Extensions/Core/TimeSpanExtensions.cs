using System;

namespace KamiSama.Extensions
{
	public static class TimeSpanExtensions
	{
		public static TimeSpan Milliseconds(this double x)
			=> TimeSpan.FromMilliseconds(x);

		public static TimeSpan Seconds(this double x)
			=> TimeSpan.FromSeconds(x);

		public static TimeSpan Minutes(this double x)
			=> TimeSpan.FromMinutes(x);

		public static TimeSpan Hours(this double x)
			=> TimeSpan.FromHours(x);

		public static TimeSpan Days(this double x)
			=> TimeSpan.FromDays(x);

		public static TimeSpan Milliseconds(this int x)
			=> ((double) x).Milliseconds();

		public static TimeSpan Seconds(this int x)
			=> ((double) x).Seconds();

		public static TimeSpan Minutes(this int x)
			=> ((double) x).Minutes();

		public static TimeSpan Hours(this int x)
			=> ((double)x).Hours();

		public static TimeSpan Days(this int x)
			=> ((double) x).Days();
	}
}
