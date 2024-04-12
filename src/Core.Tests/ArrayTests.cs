namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class ArrayTests
{
	[TestMethod]
	public void PaddingTest()
	{
		var arr = "0102030405".FromHex();
		var padded = arr.Pad(len => len % 8 == 0);

		Assert.AreEqual("0102030405000000", padded.ToHex());
		padded = padded.Pad(len => len % 8 == 0);
		Assert.AreEqual("0102030405000000", padded.ToHex());
	}
	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void Pad_with_size_smaller_than_original_array_throws_Exception()
	{
		var arr = "0102030405".FromHex();
		
		arr.Pad(2, (byte)0x00);
	}

	[TestMethod]
	public void TrimmingTest()
	{
		var arr = "0102030405000000".FromHex();
		var trimmed = arr.TrimEnd((byte)0);

		Assert.AreEqual("0102030405", trimmed.ToHex());
		trimmed = trimmed.TrimEnd((byte)0);
		Assert.AreEqual("0102030405", trimmed.ToHex());
	}
	[TestMethod]
	public void TrimmingEmptyArrayTest()
	{
		var arr = new object[] {null, null, null};
		var trimmed = arr.TrimEnd((object) null);

		CollectionAssert.AreEqual(Array.Empty<object>(), trimmed);
	}
}
