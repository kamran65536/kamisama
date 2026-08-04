namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class PersianDateTimeTests
{
	private static readonly PersianCalendar persianCalendar = new();
	[TestMethod]
	[Ignore("Platform OS Specific Test")]
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
	[TestMethod]
	[Ignore("Platform OS Specific Test")]
	public void ParsePerstringString_must_parse_persian_date_time()
	{
		var str = "01/01/0001 01:00:00 ب.ظ";
		var expected = new DateTime(1, 1, 1, 13, 0, 0, persianCalendar);

		var parsed = str.ParseAsPersianDateTime();

		Assert.AreEqual(expected, parsed);
	}
	[TestMethod]
	public void ParseExactPerstringString_must_parse_persian_date_time()
	{
		var str = "0001/01/01 01:02:03";
		var expected = new DateTime(1, 1, 1, 1, 2, 3, persianCalendar);

		var parsed = str.ParseExactAsPersianDateTime("yyyy/MM/dd HH:mm:ss");

		Assert.AreEqual(expected, parsed);
	}
	[TestMethod]
	[Ignore("Platform OS Specific Test")]
	public void TryParsePerstringString_must_parse_persian_date_time()
	{
		// This test is OS dependant
		var str = "01/01/0001 01:00:00 ب.ظ";
		var expected = new DateTime(1, 1, 1, 13, 0, 0, persianCalendar);

		var result = str.TryParseAsPersianDateTime(out DateTime parsed);

		Assert.IsTrue(result);
		Assert.AreEqual(expected, parsed);
	}
	[TestMethod]
	public void TryParsePerstringString_must_return_false_for_invalid_string()
	{
		var str = "abc";
		var result = str.TryParseAsPersianDateTime(out _);

		Assert.IsFalse(result);
	}
	[TestMethod]
	public void TryParseExactPerstringString_must_return_false_for_strings_without_exact_format()
	{
		var str = "001/01/01 01:02:03";
		var result = str.TryParseExactAsPersianDateTime("yyyy/MM/dd HH:mm:ss", out _);

		Assert.IsFalse(result);
	}
}
