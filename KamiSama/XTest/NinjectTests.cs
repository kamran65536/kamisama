using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders.Attributes;
using KamiSama.Extenders.Ninject;
using Ninject;
using Xunit;
using Xunit.Categories;

namespace XTest
{
	interface Interface1
	{
	}
	[BindTo(typeof(Interface1))]
	class C1 : Interface1
	{
	}
	interface Interface2
	{
	}
	[BindTo(typeof(Interface2), Name = "C2")]
	class C2 : Interface2
	{
	}
	[BindTo(typeof(Interface2), Name = "C3", BindingProfile = "Runtime")]
	class C3 : Interface2
	{
	}
	interface Interface3
	{
	}
	[BindTo(typeof(Interface3), IsSingleton = true)]
	class C4 : Interface3
	{
	}
	[Category("Ninject")]
	[ExcludeFromCodeCoverage]
	public class NinjectTests
	{
		[Fact(DisplayName = "Simple Profile")]
		public void TestSimpleProfile()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Runtime");

			Container.Bind<Interface1>().To<C1>().WhenProfileIs("Runtime");

			Assert.NotNull(Container.Get<Interface1>());
		}
		[Fact(DisplayName = "Differenct profiles")]
		public void TestDifferentProfiles()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Runtime");
			var kernel = new StandardKernel();

			kernel.Bind<Interface1>().To<C1	>().WhenProfileIs("Runtime2");

			Assert.Null(kernel.TryGet<Interface1>());
		}
		[Fact(DisplayName = "Simple BindTo")]
		public void TestSimpleBindTo()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");

			Container.Instance.ApplyBindToAttributes("XTest.dll");
			Assert.NotNull(Container.Get<Interface1>());
		}
		[Fact(DisplayName = "Named Injection")]
		public void TestNamedInjection()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");

			Container.Instance.ApplyBindToAttributes("XTest.dll");
			Assert.True(Container.Get<Interface2>("C2") is C2);
			Assert.True(Container.Get<Interface2>("C3") is C3);
		}
		[Fact(DisplayName = "Named Injection")]
		public void TestNamedWithBindingProfile()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime2");

			Container.Instance.ApplyBindToAttributes("XTest.dll");
			Assert.Null(Container.TryGet<Interface1>("C3"));
		}
		[Fact(DisplayName = "Singleton")]
		public void TestSingleton()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");
			Container.Instance.ApplyBindToAttributes("XTest.dll");

			var c1 = Container.TryGet<Interface3>();
			var c2 = Container.Get<Interface3>();

			Assert.True(object.ReferenceEquals(c1, c2));
		}
	}
}
