using System.Linq;

namespace KamiSama.Iso8583.Serialization
{
	/// <summary>
	/// Iso Message Extensions
	/// </summary>
	public static class IsoMessageExtensions
    {
		/// <summary>
		/// Returns serializable Iso Message
		/// </summary>
		/// <param name="message">iso message to convert</param>
		/// <param name="addBitmaps">whether add bitmap fields to serializable message or not (default is false)</param>
		/// <returns></returns>
		public static SerializableIsoMessage AsSerializable(this IsoMessage message, bool addBitmaps = false)
		{
			var result = new SerializableIsoMessage { Id = message.Id };

			var start = addBitmaps ? 0 : 2;

			result.Fields = Enumerable
				.Range(start, 129 - start)
				.Where(fieldNo => message.Has(fieldNo))
				.Select(fieldNo => message[fieldNo].AsSerializable(fieldNo))
				.ToArray();

			return result;
		}
    }
}
