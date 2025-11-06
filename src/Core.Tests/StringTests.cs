namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class StringTests
{
	[TestMethod]
	public void EmptyFromHexTest()
	{
		CollectionAssert.AreEqual(Array.Empty<byte>(), (null as string).FromHex());
	}
	[TestMethod]
	public void FromHex_must_throw_exception_on_invalid_string()
	{
		Assert.Throws<Exception>(() => "1yyy".FromHex());
	}
	[TestMethod]
	public void FromHex_must_strip_escaping_characters_from_string()
	{
		CollectionAssert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, @"
01 02	03".FromHex());
	}
	[TestMethod]
	public void EmptyToBytesTest()
	{
		CollectionAssert.AreEqual((null as string).ToBytes(), Array.Empty<byte>());
	}
	[TestMethod]
	public void FromHexTest()
	{
		var arrFromHex = "1\tA 0B\nB".FromHex();
		var arr = new byte[] { 0x01, 0xA0, 0xBB};

		CollectionAssert.AreEqual(arrFromHex, arr);
	}
	[TestMethod]
	public void FromBase64Test()
	{
		var arr = new byte[] { 0x01, 0xA0, 0xBB };
		var str = Convert.ToBase64String(arr);

		CollectionAssert.AreEqual(arr, str.FromBase64());
	}
	[TestMethod]
	public void GetBytes()
	{
		var arr1 = "012".ToBytes();

		var arr2 = "012"u8.ToArray();

		CollectionAssert.AreEqual(arr1, arr2);
	}

}
