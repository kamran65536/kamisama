using System;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using KamiSama.SecureModule.Api;
using KamiSama.SecureModule.KeySerializers;
using KamiSama.SecureModule.KeySerializers.Bson;
using KamiSama.SecureModule.LocalSsm;
using KamiSama.SecureModule.LocalSsm.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.KS_SecureModule_KeySerializers
{
	[ExcludeFromCodeCoverage]
	[TestCategory("KS.SecureModule.KeySerializers.KeySerializerBase")]
	[TestClass]
	public class KeySerializerBaseTests
	{
		class AnotherKey : IKey { }
		private IKeySerializer<SsmKey> genericSerializer;
		private IKeySerializer serializer;

		public KeySerializerBaseTests()
		{
			genericSerializer = new BsonKeySerializer<SsmKey>();
			serializer = genericSerializer;
		}
		[TestMethod]
		public void ISerializer_Serialize_must_call_generic_method()
		{
			var key = SsmKey.CreatePlainKey(Algorithm.Aes, "6DC9E96A273CAFF2543B706011161E39".FromHex());
			var result1 = genericSerializer.SerializeKey(key).ToHex();
			var result2 = serializer.SerializeKey(key).ToHex();

			Assert.AreEqual(result1, result2);
		}
		[TestMethod]
		public void ISerializer_Serialize_must_throw_Exception_on_types_other_than_SsmKey()
		{
			var anotherKey = new AnotherKey();

			Assert.ThrowsException<InvalidCastException>(() => serializer.SerializeKey(anotherKey));
		}
		[TestMethod]
		public void Serialize_throws_Exception_on_null_key()
		{
			Assert.ThrowsException<NullReferenceException>(() => genericSerializer.SerializeKey(null));
		}
		[TestMethod]
		public void ISerializer_Deserialize_must_call_generic_method()
		{
			var data = "3F00000010416C676F726974686D0003000000054B6579446174610010000000006DC9E96A273CAFF2543B706011161E39084973506C61696E4B6579000100".FromHex();
			var key1 = serializer.DeserializeKey(data) as SsmKey;
			var key2 = genericSerializer.DeserializeKey(data);

			Assert.IsNotNull(key1);
			Assert.AreEqual(key2.Algorithm, key1.Algorithm);
			Assert.AreEqual(key2.KeyData.ToHex(), key1.KeyData.ToHex());
			Assert.AreEqual(key2.IsPlainKey, key1.IsPlainKey);
		}
		[TestMethod]
		public void Deerialize_throws_Exception_on_null_key()
		{
			Assert.ThrowsException<NullReferenceException>(() => genericSerializer.DeserializeKey(null));
		}
	}
}
