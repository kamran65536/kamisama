using KamiSama.Extensions;
using System;
using System.IO;
using System.Xml.Serialization;

namespace KamiSama.Iso8583.Serialization
{
	/// <summary>
	/// Serializable iso message
	/// </summary>
	[Serializable]
	[XmlRoot("message")]
	public class SerializableIsoMessage
	{
		/// <summary>
		/// Message Type ID (MTI)
		/// </summary>
		[XmlAttribute("id")]
		public string Id { get; set; }
		/// <summary>
		/// Iso Fields
		/// </summary>
		[XmlElement("field")]
		public SerializableIsoField[] Fields { get; set; }
		/// <summary>
		/// Loads Iso Message from file
		/// </summary>
		/// <param name="path">path to the file</param>
		/// <returns></returns>
		public static SerializableIsoMessage LoadFromXmlFile(string path)
			=> File.ReadAllText(path).DeserializeFromXml<SerializableIsoMessage>();
		/// <summary>
		/// Saves Iso Message into a path
		/// </summary>
		/// <param name="path"></param>
		public void SaveToXmlFile(string path)
			=> File.WriteAllText(path, this.SerializeToXml(settings => settings.Indent = true));
		/// <summary>
		/// Coverts to IsoMessage
		/// </summary>
		/// <returns></returns>
		public IsoMessage AsIsoMessage()
		{
			var result = new IsoMessage(Id);

			foreach (var field in Fields)
				if (field.FieldNo > 1) //skipping bitmap fields
					result[field.FieldNo] = field.GetIsoField();

			return result;
		}
    }
}
