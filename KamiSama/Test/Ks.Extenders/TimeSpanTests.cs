using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks.Extenders
{
	[TestClass]
	[TestCategory("KS.Ex.TimeSpan")]
	[ExcludeFromCodeCoverage]
	public class TimeSpanTests
	{
		[TestMethod]
		public void MillisecondsTest()
			=> AssertEx.AreEqual(13.Milliseconds(), TimeSpan.FromMilliseconds(13));
		[TestMethod]
		public void SecondsTest()
			=> AssertEx.AreEqual(13.Seconds(), TimeSpan.FromSeconds(13));
		[TestMethod]
		public void MinutesTest()
			=> AssertEx.AreEqual(13.Minutes(), TimeSpan.FromMinutes(13));
		[TestMethod]
		public void HoursTest()
			=> AssertEx.AreEqual(13.Hours(), TimeSpan.FromHours(13));
		[TestMethod]
		public void DayssTest()
			=> AssertEx.AreEqual(13.Days(), TimeSpan.FromDays(13));
	}
}
