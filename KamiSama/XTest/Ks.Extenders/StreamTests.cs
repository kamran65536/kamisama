using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using Xunit;


namespace XTest.Ks.Extenders
{
	[ExcludeFromCodeCoverage]
	[Trait("Category", "KS.Ex.Stream")]
	public class StreamTests
	{
		[Fact(DisplayName = "Empty Stream")]
		public static void EmptyStreamReadTest()
		{
			var memStream = new MemoryStream();

			Assert.ThrowsAny<Exception>(() => memStream.ReadComplete(4, 10));
		}
		[Fact(DisplayName = "Closed Stream")]
		public static void ClosedStreamTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			memStream.Close();
			Assert.ThrowsAny<Exception>(() => memStream.ReadComplete(4, 10));
		}
		[Fact(DisplayName = "Complete Read")]
		public static void CompleteReadTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			var result = memStream.ReadComplete(4);

			Assert.Equal("01020304", result.ToHex());
		}

		[Fact(DisplayName = "Write")]
		public static void WriteTest()
		{
			var memStream = new MemoryStream();

			memStream.Write("01020304".FromHex());

			Assert.Equal("01020304".FromHex(), memStream.ToArray());
		}
	}
}
