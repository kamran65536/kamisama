using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Extenders.Attributes;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Syntax;

namespace KamiSama.Extenders.Ninject
{
	internal class AttributeBasedBindingGenerator  : IBindingGenerator
	{
		private static IBindingWhenInNamedWithOrOnSyntax<object> ApplyBinding(BindToAttribute attr, Type type, IBindingRoot bindingRoot)
		{
			var syntax = bindingRoot
				.Bind(attr.BindedType)
				.To(type)
				.WhenProfileIs(attr.BindingProfile ?? "Default");

			if (attr.IsSingleton)
				syntax = syntax.InSingletonScope() as IBindingInNamedWithOrOnSyntax<object>;

			if (!string.IsNullOrWhiteSpace(attr.Name))
				syntax = syntax.Named(attr.Name) as IBindingInNamedWithOrOnSyntax<object>;

			return syntax as IBindingWhenInNamedWithOrOnSyntax<object>;
		}

		[ExcludeFromCodeCoverage]
		IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> IBindingGenerator.CreateBindings(Type type, IBindingRoot bindingRoot)
		{
			if (type.IsAbstract || type.IsInterface)
				yield break;

			var all = type
				.GetCustomAttributes(typeof(BindToAttribute), true)
				.Cast<BindToAttribute>()
				.ToArray();

			foreach (var attr in all)
			{
				var syntax = ApplyBinding(attr, type, bindingRoot);

				if (syntax != null)
					yield return syntax;
			}
		}
	}
}