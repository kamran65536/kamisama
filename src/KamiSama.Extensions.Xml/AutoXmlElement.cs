using System;

namespace KamiSama.Extensions
{
	/// <summary>
	/// This class wraps an element in order to always have the same name outside while inside is different
	/// </summary>
	public class AutoXmlElement<TValue> : IEquatable<AutoXmlElement<TValue>>
	{
		/// <summary>
		/// inner element
		/// </summary>
		[AutoXmlElement]
		public TValue Value { get; set; }
		/// <summary>
		/// implicit operator to convert <typeparamref name="TValue"/> to <see cref="AutoXmlElement{TElement}"/>
		/// </summary>
		/// <param name="value"></param>
		public static implicit operator AutoXmlElement<TValue>(TValue value) => new() { Value = value };
		/// <inheritdoc	/>
		public bool Equals(AutoXmlElement<TValue> other)
		{
			if (other == null)
				return false;
			if (Value == null)
				return other.Value == null;
			else
				return Value.Equals(other.Value);
		}
		/// <inheritdoc />
		public override bool Equals(object obj) => Equals(obj as AutoXmlElement<TValue>);
		/// <inheritdoc />
		public override int GetHashCode() => HashCode.Combine(Value);
	}
}
