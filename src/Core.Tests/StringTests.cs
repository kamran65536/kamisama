namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class StringTests
{
	[TestMethod]
	public void EmptyFromHexTest()
	{
		Assert.AreSequenceEqual([], (null as string).FromHex());
	}
	[TestMethod]
	public void FromHex_must_throw_exception_on_invalid_string()
	{
		Assert.Throws<Exception>(() => "1yyy".FromHex());
	}
	[TestMethod]
	public void FromHex_must_strip_escaping_characters_from_string()
	{
		Assert.AreSequenceEqual(new byte[] { 0x01, 0x02, 0x03 }, @"
01 02	03".FromHex());
	}
	[TestMethod]
	public void EmptyToBytesTest()
	{
		Assert.AreSequenceEqual((null as string).ToBytes(), []);
	}
	[TestMethod]
	public void FromHexTest()
	{
		var arrFromHex = "1\tA 0B\nB".FromHex();
		var arr = new byte[] { 0x01, 0xA0, 0xBB};

		Assert.AreSequenceEqual(arrFromHex, arr);
	}
	[TestMethod]
	public void FromBase64Test()
	{
		var arr = new byte[] { 0x01, 0xA0, 0xBB };
		var str = Convert.ToBase64String(arr);

		Assert.AreSequenceEqual(arr, str.FromBase64());
	}
	[TestMethod]
	public void GetBytes()
	{
		var arr1 = "012".ToBytes();

		var arr2 = "012"u8.ToArray();

		Assert.AreSequenceEqual(arr1, arr2);
	}

}
