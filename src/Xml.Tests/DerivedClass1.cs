namespace KamiSama.Extensions.Xml.Tests;

public class DerivedClass1 : AbstractClass, IEquatable<DerivedClass1>
{
	public int X { get; set; }

	public bool Equals(DerivedClass1 other)
	{
		return (other != null) && (X == other.X);
	}
	public override bool Equals(object obj) => Equals(obj as DerivedClass1);

	public override int GetHashCode()
	{
		return HashCode.Combine(X);
	}
}
