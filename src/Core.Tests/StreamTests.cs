namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class StreamTests
{
	[TestMethod]
	public void ReadExact_from_empty_stream_must_throw_Exception()
	{
		var memStream = new MemoryStream();

		Assert.Throws<Exception>(() => memStream.ReadExact(4, 10));
	}
	[TestMethod]
	public void ReadExact_from_closed_stream_throws_Exception()
	{
		var memStream = new MemoryStream("01020304".FromHex());
		memStream.Seek(0, SeekOrigin.Begin);
		memStream.Close();
		Assert.Throws<Exception>(() => memStream.ReadExact(4, 10));
	}
	[TestMethod]
	public async Task ReadExactAsync_from_closed_stream_throws_Exception()
	{
		var memStream = new MemoryStream("01020304".FromHex());
		memStream.Seek(0, SeekOrigin.Begin);
		memStream.Close();
		await Assert.ThrowsAsync<Exception>(async () => await memStream.ReadExactAsync(4, CancellationToken.None));
	}
	[TestMethod]
	public void ReadExact_reads_exactly_expected_bytes()
	{
		var memStream = new MemoryStream("01020304".FromHex());
		memStream.Seek(0, SeekOrigin.Begin);
		var result = memStream.ReadExact(4);

		Assert.AreEqual("01020304", result.ToHex());
	}
	[TestMethod]
	public async Task ReadExactAsync_reads_exactly_expected_bytes()
	{
		var memStream = new MemoryStream("01020304".FromHex());
		memStream.Seek(0, SeekOrigin.Begin);
		var result = await memStream.ReadExactAsync(4, CancellationToken.None); 

		Assert.AreEqual("01020304", result.ToHex());
	}
}
