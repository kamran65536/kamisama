using System.Linq;

namespace KamiSama.Iso8583.Xml
{
	public static class IsoMessageExtender
    {
		public static XmlIsoMessage GetXmlIsoMessage(this IsoMessage message, bool addBitmaps = false)
		{
			var result = new XmlIsoMessage { Id = message.Id };

			var start = addBitmaps ? 0 : 2;

			result.Fields = Enumerable
				.Range(start, 129 - start)
				.Where(fieldNo => message.Has(fieldNo))
				.Select(fieldNo => message[fieldNo].GetXmlIsoField(fieldNo))
				.ToArray();

			return result;
		}
    }
}
