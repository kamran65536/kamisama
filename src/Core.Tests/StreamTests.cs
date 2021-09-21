using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Extensions.Core.Tests
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class StreamTests
	{
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		public void ReadExact_from_empty_stream_must_throw_Exception()
		{
			var memStream = new MemoryStream();

			memStream.ReadExact(4, 10);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		public void ReadExact_from_closed_stream_throws_Exception()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			memStream.Close();
			memStream.ReadExact(4, 10);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		public async Task ReadExactAsync_from_closed_stream_throws_Exception()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			memStream.Close();
			await memStream.ReadExactAsync(4, CancellationToken.None);
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
}
