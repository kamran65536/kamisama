using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using XTest.DataTypes;
using Xunit;


namespace XTest.Ks.Extenders.Serialization
{
	[Trait("Category", "KS.Ex.Xml Serialization")]
	[ExcludeFromCodeCoverage]
	public class XmlSerializationTests
	{
		private static readonly object testObj = new Kamran
		{
			X = 10,
			Y = "Salaam",
			Kami = new Kami
			{
				DateTime = DateTime.Now,
				D = 1.0
			}
		};
		[Fact(DisplayName = "String")]
		public void StringSerialization()
		{
			Assert.Equal(testObj, testObj.Serialize(true).Deserialize<Kamran>());
			Assert.Equal(testObj, testObj.Serialize(false).Deserialize<Kamran>());
		}
		[Fact(DisplayName = "TextReader/Writer")]
		public void TextReaderWriterSerialization()
		{
			var writer1 = new StringWriter();
			var writer2 = new StringWriter();

			testObj.Serialize(writer1, true);
			testObj.Serialize(writer2, false);

			var reader1 = new StringReader(writer1.ToString());
			var reader2 = new StringReader(writer2.ToString());

			Assert.Equal(testObj, reader1.Deserialize<Kamran>());
			Assert.Equal(testObj, reader2.Deserialize<Kamran>());
		}
		[Fact(DisplayName = "Stream")]
		public void StreamSerialization()
		{
			var stream1 = new MemoryStream();
			var stream2 = new MemoryStream();

			testObj.Serialize(stream1, true);
			testObj.Serialize(stream2, false);

			var stream3 = new MemoryStream(stream1.ToArray());
			var stream4 = new MemoryStream(stream2.ToArray());

			Assert.Equal(testObj, stream3.Deserialize<Kamran>());
			Assert.Equal(testObj, stream4.Deserialize<Kamran>());
		}

		[Fact(DisplayName = "FileInfo")]
		public void FileInfoTest()
		{
			var fileInfo = new FileInfo("./test.txt");

			testObj.Serialize(fileInfo, true);

			var tmp = fileInfo.Deserialize<Kamran>();

			Assert.Equal(testObj, tmp);

			testObj.Serialize(fileInfo, false);

			tmp = fileInfo.Deserialize<Kamran>();

			Assert.Equal(testObj, tmp);
		}
	}
}