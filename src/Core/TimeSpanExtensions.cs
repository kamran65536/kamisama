namespace KamiSama.Extensions;

/// <summary>
/// Provides fluent numeric extensions for constructing <see cref="TimeSpan"/> values in common units.
/// Both integer and fractional values are supported.
/// </summary>
public static class TimeSpanExtensions
{
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of milliseconds.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Milliseconds(this double x)
		=> TimeSpan.FromMilliseconds(x);
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of seconds.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Seconds(this double x)
		=> TimeSpan.FromSeconds(x);
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of minutes.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Minutes(this double x)
		=> TimeSpan.FromMinutes(x);
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of hours.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Hours(this double x)
		=> TimeSpan.FromHours(x);
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of days.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Days(this double x)
		=> TimeSpan.FromDays(x);
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of milliseconds.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Milliseconds(this int x)
		=> ((double)x).Milliseconds();
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of seconds.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Seconds(this int x)
		=> ((double)x).Seconds();
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of minutes.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Minutes(this int x)
		=> ((double)x).Minutes();
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of hours.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Hours(this int x)
		=> ((double)x).Hours();
	/// <summary>
	/// Returns a System.TimeSpan that represents a specified number of days.
	/// </summary>
	/// <param name="x"></param>
	/// <returns></returns>
	public static TimeSpan Days(this int x)
		=> ((double)x).Days();
}
