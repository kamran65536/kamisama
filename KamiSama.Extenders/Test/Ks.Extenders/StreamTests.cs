using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Ks.Extenders
{
	[ExcludeFromCodeCoverage]
	[TestClass]
	[TestCategory("KS.Ex.Stream")]
	public class StreamTests
	{
		[TestMethod]
		public void EmptyStreamReadTest()
		{
			var memStream = new MemoryStream();

			AssertEx.ThrowsException<Exception>(() => memStream.ReadComplete(4, 10));
		}
		[TestMethod]
		public void ClosedStreamTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			memStream.Close();
			AssertEx.AnyException<Exception>(() => memStream.ReadComplete(4, 10));
		}
		[TestMethod]
		public void CompleteReadTest()
		{
			var memStream = new MemoryStream("01020304".FromHex());
			memStream.Seek(0, SeekOrigin.Begin);
			var result = memStream.ReadComplete(4);

			AssertEx.AreEqual("01020304", result.ToHex());
		}

		[TestMethod]
		public void WriteTest()
		{
			var memStream = new MemoryStream();

			memStream.Write("01020304".FromHex());

			AssertEx.AreEqual("01020304".FromHex(), memStream.ToArray());
		}
	}
}
