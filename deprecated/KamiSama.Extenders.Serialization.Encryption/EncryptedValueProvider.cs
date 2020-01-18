//using System;
//using System.IO;
//using System.Reflection;
//using System.Security.Cryptography;
//using System.Text;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Bson;
//using Newtonsoft.Json.Serialization;

//namespace KamiSama.Extenders.Serialization.Encryption
//{
//	public class EncryptedValueProvider : IValueProvider
//	{
//		private readonly byte[] _key;
//		private readonly JsonProperty jsonProperty;

//		public EncryptedValueProvider(IContractResolver resolver, JsonProperty jsonProperty, byte[] key)
//		{
//			this._key = key;
//			this.jsonProperty = jsonProperty;
//		}

//		public object GetValue(object target)
//		{
//			var value = jsonProperty.Converter.w

//			if (value == null)
//				return null;

//			byte[] data;

//			if (_memberType == typeof(byte[]))
//				data = (byte[])value;
//			else if (_memberType == typeof(string))
//				data = ((string)value).ToBytes(Encoding.UTF8);
//			else if (_memberType.IsPrimitive)
//				data = Convert.ToString(value).ToBytes(Encoding.UTF8);
//			else
//			{
//				using (var stream = new MemoryStream())
//				{
//					using (var writer = new BsonDataWriter(stream))
//						_serializer.Serialize(writer, value, _memberType);

//					data = stream.ToArray();
//				}
//			}

//			return data.AesEncrypt(_key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);
//		}

//		public void SetValue(object target, object value)
//		{
//			if (value == null)
//			{
//				_provider.SetValue(target, value);
//				return;
//			}
//			if (!(value is byte[] cipher))
//				throw new InvalidOperationException("Encrpted field data must be byte[]");

//			var data = cipher.AesDecrypt(_key, cipherMode: CipherMode.CBC, padding: PaddingMode.PKCS7);

//			if (_memberType == typeof(byte[]))
//				_provider.SetValue(target, data);
//			else if (_memberType == typeof(string))
//				_provider.SetValue(target, data.GetString(Encoding.UTF8));
//			else if (_memberType.IsPrimitive)
//				_provider.SetValue(target, Convert.ChangeType(data.GetString(Encoding.UTF8), _memberType));
//			else
//			{
//				using (var stream = new MemoryStream(data))
//				{
//					using (var reader = new BsonDataReader(stream))
//						_provider.SetValue(target, _serializer.Deserialize(reader, _memberType));
//				}
//			}
//		}
//	}

//}
