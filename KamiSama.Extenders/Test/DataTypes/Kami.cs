using System;
using System.Diagnostics.CodeAnalysis;

namespace Test.DataTypes
{
	[ExcludeFromCodeCoverage()]
	public class Kami : IEquatable<Kami>
	{
		public double D { get; set; }
		public DateTime DateTime { get; set; }

		public bool Equals(Kami other)
		{
			return other != null && Math.Abs(other.D - D) < 0.0001 && other.DateTime == DateTime;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Kami);
		}

		public override int GetHashCode()
		{
			return D.GetHashCode() ^ DateTime.GetHashCode();
		}
	}
}