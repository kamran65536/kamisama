namespace KamiSama.Extensions.Xml.Tests;

public class DerivedClass2 : AbstractClass, IEquatable<DerivedClass2>
{
	public string? Str { get; set; }
	public bool Equals(DerivedClass2? other)
	{
		return (other != null) && (Str == other.Str);
	}
	public override bool Equals(object? obj) => Equals(obj as DerivedClass2);

	public override int GetHashCode()
	{
		return HashCode.Combine(Str);
	}
}
