using KamiSama.Extensions.DependencyInjection.Tests.DataTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamiSama.Extensions.DependencyInjection.Tests
{
	[TestClass]
	public class ServiceProviderExtensionsTests
	{
		[TestMethod]
		public void GetService_must_return_named_instance_if_found()
		{
			var services = new ServiceCollection();

			services.AddTransient<ISampleInteface, SampleImplementation1>("name1");

			var provider = services.BuildServiceProvider();

			var implementation = provider.GetService(typeof(ISampleInteface), "name1");

			Assert.IsNotNull(implementation);
			Assert.IsInstanceOfType(implementation, typeof(SampleImplementation1));
		}
	}
}
