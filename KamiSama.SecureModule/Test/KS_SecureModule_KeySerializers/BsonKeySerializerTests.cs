using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiSama.Extenders;
using KamiSama.SecureModule.KeySerializers.Bson;
using KamiSama.SecureModule.LocalSsm;
using KamiSama.SecureModule.LocalSsm.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Test.KS_SecureModule_KeySerializers
{
	[TestClass]
	[TestCategory("KS.SecureModule.KeySerializers.BsonKeySerializer")]
	[ExcludeFromCodeCoverage]
	public class BsonKeySerializerTests
	{
		private BsonKeySerializer<SsmKey> serializer = new BsonKeySerializer<SsmKey>();

		[TestMethod]
		public void Serialize_must_return_bson_value()
		{
			var key = SsmKey.CreatePlainKey(Algorithm.Aes, "6DC9E96A273CAFF2543B706011161E39".FromHex());
			var str = key.SerializeToJson(Formatting.None);
			var result = serializer.SerializeKey(key);

			Assert.AreEqual("3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100", result.ToHex());
		}
		[TestMethod]
		public void Deserialize_must_return_ssm_key()
		{
			var data = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();

			var key = serializer.DeserializeKey(data);

			Assert.IsNotNull(key);
			Assert.AreEqual(Algorithm.Aes, key.Algorithm);
			Assert.AreEqual("6DC9E96A273CAFF2543B706011161E39", key.KeyData.ToHex());
			Assert.AreEqual(true, key.IsPlainKey);
		}
	}
}
