using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Extenders.Attributes;
using KamiSama.Extenders.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;


namespace Test.Ks.Extenders.Ninject
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
	[BindTo(typeof(Interface3), Name = "C5")]
	abstract class C5 : Interface3
	{
	}
	[BindTo(typeof(Interface3), Name = "I4")]
	abstract class Interface4 : Interface3
	{
	}
	[TestCategory("KS.Ex.Ninject")]
	[ExcludeFromCodeCoverage]
	[TestClass]
	public class NinjectTests
	{
		[TestMethod]
		public void TestSimpleProfile()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Runtime");

			Container.Bind<Interface1>().To<C1>().WhenProfileIs("Runtime");

			Assert.IsNotNull(Container.Get<Interface1>());
		}
		[TestMethod]
		public void TestDifferentProfiles()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Runtime");
			var kernel = new StandardKernel();

			kernel.Bind<Interface1>().To<C1>().WhenProfileIs("Runtime2");

			Assert.IsNull(kernel.TryGet<Interface1>());
		}
		[TestMethod]
		public void TestSimpleBindTo()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");

			Container.Instance.ApplyBindToAttributes("Test.dll");
			Assert.IsNotNull(Container.Get<Interface1>());
		}
		[TestMethod]
		public void TestNamedInjection()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");

			Container.Instance.ApplyBindToAttributes("Test.dll");
			Assert.IsTrue(Container.Get<Interface2>("C2") is C2);
			Assert.IsTrue(Container.Get<Interface2>("C3") is C3);
		}
		[TestMethod]
		public void TestNamedWithBindingProfile()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime2");

			Container.Instance.ApplyBindToAttributes("Test.dll");
			Assert.IsNull(Container.TryGet<Interface1>("C3"));
		}
		[TestMethod]
		public void TestSingleton()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");
			Container.Instance.ApplyBindToAttributes("Test.dll");

			var c1 = Container.TryGet<Interface3>();
			var c2 = Container.Get<Interface3>();

			Assert.IsTrue(object.ReferenceEquals(c1, c2));
		}
		[TestMethod]
		public void TestGetAll()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");
			Container.Instance.ApplyBindToAttributes("Test.dll");

			Assert.AreEqual(2, Container.GetAll<Interface2>().Count());
		}
		[TestMethod]
		public void TestAbstractOrInterface()
		{
			Container.Reset();
			Container.ActiveProfiles.Clear();
			Container.ActiveProfiles.Add("Default");
			Container.ActiveProfiles.Add("Runtime");
			Container.Instance.ApplyBindToAttributes("Test.dll");

			Assert.IsNull(Container.TryGet<Interface3>("C5"));
			Assert.IsNull(Container.TryGet<Interface3>("I4"));
		}
	}
}
