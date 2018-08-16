using System;
using System.IO;
using KamiSama.SecureModule.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace KamiSama.SecureModule.KeySerializers.Bson
{
	public class BsonKeySerializer<_KeyType> : KeySerializerBase<_KeyType>
		where _KeyType : IKey
	{
		private JsonSerializer jsonSerializer;

		public BsonKeySerializer()
		{
			this.jsonSerializer = JsonSerializer.CreateDefault();
		}

		public override _KeyType DeserializeKey(byte[] keyData)
		{
			if (keyData == null)
				throw new NullReferenceException("Key data cannot be null.");

			using (var memStream = new MemoryStream(keyData))
				using (var bsonReader = new BsonDataReader(memStream))
					return jsonSerializer.Deserialize<_KeyType>(bsonReader);
		}

		public override byte[] SerializeKey(_KeyType key)
		{
			if (key == null)
				throw new NullReferenceException("Key cannot be null.");

			using (var memStream = new MemoryStream())
			{
				using (var bsonWriter = new BsonDataWriter(memStream))
					jsonSerializer.Serialize(bsonWriter, key);

				return memStream.ToArray();
			}
		}
	}
}
