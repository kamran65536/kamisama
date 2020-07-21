using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Repositories.Tests
{
	public class SampleEntity : IEquatable<SampleEntity>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public bool Equals([AllowNull] SampleEntity other)
			=>
			(other != null) &&
			(Id == other.Id) &&
			(Name == other.Name);
		public override bool Equals(object obj) => Equals(obj as SampleEntity);
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name);
		}
	}
}
