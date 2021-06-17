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
		public TElement Value { get; set; }
		/// <summary>
		/// implicit operator to convert <typeparamref name="TElement"/> to <see cref="AutoXmlElement{TElement}"/>
		/// </summary>
		/// <param name="value"></param>
		public static implicit operator AutoXmlElement<TElement>(TElement value) => new() { Value = value };
	}
}
