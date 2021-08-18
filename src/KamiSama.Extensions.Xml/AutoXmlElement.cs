using System;

namespace KamiSama.Extensions
{
	/// <summary>
	/// This class wraps an element in order to always have the same name outside while inside is different
	/// </summary>
	public class AutoXmlElement<TValue> : IEquatable<AutoXmlElement<TValue>>, IEquatable<TValue>
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
		bool IEquatable<AutoXmlElement<TValue>>.Equals(AutoXmlElement<TValue> other)
		{
			if (other == null)
				return false;
			if (Value == null)
				return other.Value == null;
			else
				return Value.Equals(other.Value);
		}
		/// <inheritdoc/>
		bool IEquatable<TValue>.Equals(TValue value) => object.Equals(Value, value);
		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (obj is AutoXmlElement<TValue> element)
				return Equals(element);
			else if (obj is TValue value)
				return Equals(value);
			else
				return false;
		}
		/// <inheritdoc />
		public override int GetHashCode() => HashCode.Combine(Value);
	}
}
