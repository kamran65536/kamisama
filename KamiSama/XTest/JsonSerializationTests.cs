using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using KamiSama.Extenders;
using Newtonsoft.Json;
using XTest.DataTypes;
using Xunit;
using Xunit.Categories;

namespace XTest
{
	[Category("Json Serialization")]
	[ExcludeFromCodeCoverage]
	public class JsonSerializationTests
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
			Assert.Equal(testObj, testObj.SerializeToJson(Formatting.Indented).DeserializeFromJson<Kamran>());
			Assert.Equal(testObj, testObj.SerializeToJson(Formatting.None).DeserializeFromJson<Kamran>());
		}
		[Fact(DisplayName = "TextReader/Writer")]
		public void TextReaderWriterSerialization()
		{
			var writer1 = new StringWriter();
			var writer2 = new StringWriter();

			testObj.SerializeToJson(writer1, Formatting.Indented);
			testObj.SerializeToJson(writer2, Formatting.None);

			var reader1 = new StringReader(writer1.ToString());
			var reader2 = new StringReader(writer2.ToString());

			Assert.Equal(testObj, reader1.DeserializeFromJson<Kamran>());
			Assert.Equal(testObj, reader2.DeserializeFromJson<Kamran>());
		}
		[Fact(DisplayName = "Stream")]
		public void StreamSerialization()
		{
			var stream1 = new MemoryStream();
			var stream2 = new MemoryStream();

			testObj.SerializeToJson(stream1, Formatting.Indented);
			testObj.SerializeToJson(stream2, Formatting.None);

			var stream3 = new MemoryStream(stream1.ToArray());
			var stream4 = new MemoryStream(stream2.ToArray());

			Assert.Equal(testObj, stream3.DeserializeFromJson<Kamran>());
			Assert.Equal(testObj, stream4.DeserializeFromJson<Kamran>());
		}
		[Fact(DisplayName = "FileInfo")]
		public void FileInfoTest()
		{
			var fileInfo = new FileInfo("./test.json");

			testObj.SerializeToJson(fileInfo, Formatting.Indented);

			var tmp = fileInfo.DeserializeFromJson<Kamran>();

			Assert.Equal(testObj, tmp);

			testObj.SerializeToJson(fileInfo, Formatting.None);

			tmp = fileInfo.DeserializeFromJson<Kamran>();

			Assert.Equal(testObj, tmp);
		}
	}
}