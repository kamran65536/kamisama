using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using System;
using System.Globalization;

namespace KamiSama.Extensions.NLog.Tests
{
	[TestClass]
	public class PersianDateLayoutRendererTests
	{
		[TestMethod]
		public void Append_must_add_layout_with_default_format()
		{
			var log = new LogEventInfo
			{
				TimeStamp = new DateTime(1399, 1, 1, 13, 15, 35, 135, new PersianCalendar())
			};

			var renderer = new PersianDateLayoutRenderer();

			var result = renderer.Render(log);

			Assert.AreEqual("1399/01/01 13:15:35.135", result);
		}
		[TestMethod]
		public void Append_must_add_layout_with_custom_format()
		{
			var log = new LogEventInfo
			{
				TimeStamp = new DateTime(1399, 1, 1, 13, 15, 35, 135, new PersianCalendar())
			};

			var renderer = new PersianDateLayoutRenderer
			{
				Format = "hh:mm:ss.fff"
			};

			var result = renderer.Render(log);

			Assert.AreEqual("01:15:35.135", result);
		}
	}
}
