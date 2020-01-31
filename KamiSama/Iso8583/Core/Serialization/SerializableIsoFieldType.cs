namespace KamiSama.Iso8583.Serialization
{
	/// <summary>
	/// Serializable Iso Field Type
	/// </summary>
	public enum SerializableIsoFieldType
    {
		/// <summary>
		/// String data
		/// </summary>
		String = 1,
		/// <summary>
		/// Binary data in hexadecimal form
		/// </summary>
		BinaryHex = 2,
		/// <summary>
		/// Bitmap field data in hexadecimal form
		/// </summary>
		BitmapHex = 3
    }
}
