namespace KamiSama.Extensions.NLog.Tests;

[TestClass]
public class PersianShortDateLayoutRendererTests
{
	[TestMethod]
	public void Append_must_add_shortDate_in_persian_calendar()
	{
		var log = new LogEventInfo
		{
			TimeStamp = new DateTime(1399, 1, 5, 13, 15, 35, 135, new PersianCalendar())
		};

		var renderer = new PersianShortDateLayoutRenderer();

		var result = renderer.Render(log);

		Assert.AreEqual("1399-01-05", result);
	}
}
