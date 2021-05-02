using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.Xml.Tests
{
	public class ParentRoot : IEquatable<ParentRoot>
	{
		public int P { get; set; }
		public int F;

		public ExampleClass ExampleRoot { get; set; }

		public bool Equals(ParentRoot other)
		{
			return
				(other != null) &&
				(P == other.P) &&
				(F == other.F) &&
				ExampleRoot.Equals(other.ExampleRoot);
		}
		public override bool Equals(object obj) => Equals(obj as ParentRoot);

		public override int GetHashCode()
		{
			return HashCode.Combine(P, F, ExampleRoot);
		}
	}
}
