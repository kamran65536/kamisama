using Ninject.Syntax;

namespace KamiSama.Extenders.Ninject
{
	public static class SyntexExtender
    {
		public static IBindingInNamedWithOrOnSyntax<T> WhenProfileIs<T>(this IBindingWhenInNamedWithOrOnSyntax<T> binding, string profileName)
			=> binding.When(req => Container.ActiveProfiles.Contains(profileName));
	}
}
