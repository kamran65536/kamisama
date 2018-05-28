using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extenders.Attributes
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class BindToAttribute : Attribute
	{
		public Type BindedType { get; private set; }
		public string Name { get; set; }
		public string BindingProfile { get; set; }
		public bool IsSingleton { get; set; } = false;

		public BindToAttribute(Type bindedType)
		{
			this.BindedType = bindedType;
		}
	}
}
