using Ninject;
using Ninject.Extensions.Conventions;

namespace KamiSama.Extenders.Ninject
{
	public static class KernelExtender
	{
		public static void ApplyBindToAttributes(this IKernel kernel, params string[] assemblyPatterns)
		{
			var defaultBindingGenerator = new AttributeBasedBindingGenerator();
			kernel.Bind(x =>
			{
				x
					.FromAssembliesMatching(assemblyPatterns)
					.IncludingNonPublicTypes()
					.SelectAllClasses()
					.BindWith(defaultBindingGenerator);
			});
		}
	}
}
