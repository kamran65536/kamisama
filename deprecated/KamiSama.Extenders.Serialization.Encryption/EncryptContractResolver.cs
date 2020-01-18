//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using KamiSama.Extenders.Attributes;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;

//namespace KamiSama.Extenders.Serialization.Encryption
//{
//	public class EncryptContractResolver : DefaultContractResolver
//	{
//		public EncryptContractResolver()
//		{
//		}

//		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
//		{
//			var props = base.CreateProperties(type, memberSerialization);

//			foreach (JsonProperty prop in props)
//			{
//				var pi = type.GetProperty(prop.UnderlyingName);
//				var attr = pi?.GetCustomAttribute<EncryptedAttribute>(true);
//				if (attr != null)
//				{
//					prop.ValueProvider =
//						new EncryptedValueProvider(this, prop, attr.Key);

//					prop.PropertyType = typeof(byte[]);
//				}
//			}

//			return props;
//		}
//	}
//}
