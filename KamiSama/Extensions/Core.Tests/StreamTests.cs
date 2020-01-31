using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;


namespace KamiSama.Extensions.Core.Tests
{
	[TestClass]
	public class StreamTests
	{
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		[ExcludeFromCodeCoverage]
		public void EmptyStreamReadTest()
		{
			var memStream = new MemoryStream();

			memStream.ReadComplete(4, 10);
		}
		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		[ExcludeFromCodeCoverage]
		public void ClosedStreamTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			memStream.Close();
			memStream.ReadComplete(4, 10);
		}
		[TestMethod]
		public void CompleteReadTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			var result = memStream.ReadComplete(4);

			Assert.AreEqual("01020304", result.ToHex());
		}
		[TestMethod]
		public void WriteTest()
		{
			var memStream = new MemoryStream();

			memStream.Write("01020304".FromHex());

			CollectionAssert.AreEqual("01020304".FromHex(), memStream.ToArray());
		}
	}
}
