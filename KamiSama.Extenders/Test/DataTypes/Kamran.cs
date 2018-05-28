using System;
using System.Diagnostics.CodeAnalysis;

namespace Test.DataTypes
{
	[ExcludeFromCodeCoverage()]
	public class Kamran : IEquatable<Kamran>
	{
		public int X { get; set; }
		public string Y { get; set; }
		public Kami Kami { get; set; }

		public bool Equals(Kamran other)
		{
			return other != null && other.X == X && other.Y == Y && other.Kami.Equals(Kami);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Kamran);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ (Y?.GetHashCode() ?? 0) ^ (Kami?.GetHashCode() ?? 0);
		}
	}
}