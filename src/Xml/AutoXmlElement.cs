using System;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Wraps a polymorphic value so its containing XML element can retain a stable name while the nested value uses its concrete type.
	/// The implicit conversion makes wrapper creation transparent to callers.
	/// </summary>
	public class AutoXmlElement<TValue> : IEquatable<AutoXmlElement<TValue>>, IEquatable<TValue>
	{
		/// <summary>
		/// Gets or sets the wrapped value serialized inside the stable outer element.
		/// </summary>
		[AutoXmlElement]
		public TValue Value { get; set; } = default!;
		/// <summary>
		/// Wraps a <typeparamref name="TValue"/> instance in an <see cref="AutoXmlElement{TValue}"/>.
		/// </summary>
		/// <param name="value"></param>
		public static implicit operator AutoXmlElement<TValue>(TValue value) => new() { Value = value };
		/// <inheritdoc	/>
		bool IEquatable<AutoXmlElement<TValue>>.Equals(AutoXmlElement<TValue>? other)
		{
			if (other == null)
				return false;
			if (Value == null)
				return other.Value == null;
			else
				return Value.Equals(other.Value);
		}
		/// <inheritdoc/>
		bool IEquatable<TValue>.Equals(TValue? value) => object.Equals(Value, value);
		/// <summary>
		/// Determines whether the supplied object is a wrapper with an equal value or a <typeparamref name="TValue"/> equal to the wrapped value.
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is AutoXmlElement<TValue> element)
				return Equals(element);
			else if (obj is TValue value)
				return Equals(value);
			else
				return false;
		}
		/// <summary>
		/// Returns a hash code derived from the wrapped value.
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(Value);
	}
}
