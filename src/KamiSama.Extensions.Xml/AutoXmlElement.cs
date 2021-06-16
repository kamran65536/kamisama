namespace KamiSama.Extensions
{
	/// <summary>
	/// This class wraps an element in order to always have the same name outside while inside is different
	/// </summary>
	public class AutoXmlElement<TElement>
	{
		/// <summary>
		/// inner element
		/// </summary>
		[AutoXmlElement]
		public TElement Element { get; set; }
	}
}
