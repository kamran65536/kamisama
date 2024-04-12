namespace KamiSama.Extensions.NLog.Tests;

[TestClass]
public class PersianLongDateLayoutRendererTests
{
	[TestMethod]
	public void Append_must_add_longDate_in_persian_calendar()
	{
		var log = new LogEventInfo
		{
			TimeStamp = new DateTime(1399, 1, 1, 13, 15, 35, 135, new PersianCalendar())
		};

		var renderer = new PersianLongDateLayoutRenderer();

		var result = renderer.Render(log);

		Assert.AreEqual("1399-01-01 13:15:35.1350", result);
	}
}
