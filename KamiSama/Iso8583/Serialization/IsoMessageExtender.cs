using System.Linq;

namespace KamiSama.Iso8583.Serialization
{
	public static class IsoMessageExtender
    {
		public static SerializableIsoMessage GetSerializableMessage(this IsoMessage message, bool addBitmaps = false)
		{
			var result = new SerializableIsoMessage { Id = message.Id };

			var start = addBitmaps ? 0 : 2;

			result.Fields = Enumerable
				.Range(start, 129 - start)
				.Where(fieldNo => message.Has(fieldNo))
				.Select(fieldNo => message[fieldNo].GetSerializableField(fieldNo))
				.ToArray();

			return result;
		}
    }
}
