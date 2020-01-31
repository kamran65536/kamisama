using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace KamiSama.Extensions.Core.Tests
{
	[TestClass]
	public class PersianDateTimeTests
	{
		private static PersianCalendar persianCalendar = new PersianCalendar();
		[TestMethod]
		public void ToPersianString_must_return_similar_as_DateTime_ToString()
		{
			var dt = new DateTime(1, 1, 1, 13, 0, 0, persianCalendar);

			Assert.AreEqual("01/01/0001 01:00:00 ب.ظ", dt.ToPersianString());
		}
		[TestMethod]
		public void ToPersianString_with_format_must_return_similar_as_DateTime_ToString()
		{
			var dt = new DateTime(1, 1, 1, 13, 0, 0, persianCalendar);

			Assert.AreEqual("0001/01/01 13:00:00", dt.ToPersianString("yyyy/MM/dd HH:mm:ss"));
		}
	}
}
