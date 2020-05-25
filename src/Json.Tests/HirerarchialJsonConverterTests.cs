using KamiSama.Extensions.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KamiSama.Extensions.Json.Tests
{
	public abstract class SampleBaseClass
	{
		[JsonHirerarchyDiscriminator]
		public abstract string Discriminator { get; }
	}
	public class TestClassWithConverter
	{
		[JsonConverter(typeof(HirerarchialJsonConverter<SampleBaseClass>))]
		public SampleBaseClass Configuration { get; set; }
	}
	public class TestClassWithoutConverter
	{
		public SampleBaseClass Configuration { get; set; }
	}
	public class SampleClass : SampleBaseClass
	{
		public override string Discriminator => "sample1";
	}
	public class BaseClassWithoutDiscriminatorProperty
	{
		public string SomeProperty { get; set; }
	}
	[TestClass]
	public class HirerarchialJsonConverterTests
	{
		[TestMethod]
		public void HirarchialJsonConverter_constructor_must_throw_TypeInitializationException_if_no_JsonHirerarchyDiscriminatorAttribute_exists()
		{
			Assert.ThrowsException<TypeInitializationException>(() => new HirerarchialJsonConverter<BaseClassWithoutDiscriminatorProperty>());
		}
		[TestMethod]
		public void Register_must_add_conifguration_to_typeMaps()
		{
			HirerarchialJsonConverter<SampleBaseClass>.typeMap.Clear();
			HirerarchialJsonConverter<SampleBaseClass>.Register<SampleClass>();

			Assert.IsTrue(HirerarchialJsonConverter<SampleBaseClass>.typeMap[new SampleClass().Discriminator] == typeof(SampleClass));
		}
		[TestMethod]
		public void Write_must_write_conifguration_with_no_change()
		{
			var sample1 = new TestClassWithConverter
			{
				Configuration = new SampleClass()
			};
			var sample2 = new TestClassWithoutConverter
			{
				Configuration = new SampleClass()
			};

			var json1 = JsonSerializer.Serialize(sample1);
			var json2 = JsonSerializer.Serialize(sample2);

			Assert.AreEqual(json1, json2);
		}
		[TestMethod]
		public void Read_must_return_null_if_json_element_is_null()
		{
			var json = @"{ ""Conifguration"": null }";

			var obj = JsonSerializer.Deserialize<TestClassWithConverter>(json);

			Assert.IsNull(obj.Configuration);

			json = @"{}";

			obj = JsonSerializer.Deserialize<TestClassWithConverter>(json);
		
			Assert.IsNull(obj.Configuration);
		}
		[TestMethod]
		public void Read_must_throw_NotSupportedException_if_discriminator_property_is_not_recognized()
		{
			HirerarchialJsonConverter<SampleBaseClass>.typeMap.Clear();

			var testClass = new TestClassWithConverter
			{
				Configuration = new SampleClass()
			};
			var json = JsonSerializer.Serialize(testClass);

			Assert.ThrowsException<NotSupportedException>(() => JsonSerializer.Deserialize<TestClassWithConverter>(json));
		}
		[TestMethod]
		public void Read_must_throw_NotSupportedException_if_discriminator_property_is_null_or_empty()
		{
			var json = @"{ ""Configuration"" : { ""Discriminator"" : null } }";

			Assert.ThrowsException<NotSupportedException>(() => JsonSerializer.Deserialize<TestClassWithConverter>(json));
		}
		[TestMethod]
		public void Read_must_throw_Exception_if_Configuration_ProviderName_key_not_present()
		{
			var json = @"{ ""Configuration"" : { ""Discriminator2"" : ""something"" } }";

			Assert.ThrowsException<Exception>(() => JsonSerializer.Deserialize<TestClassWithConverter>(json));
		}
		[TestMethod]
		public void Read_must_read_configuration_types_based_on_ChannelType()
		{
			HirerarchialJsonConverter<SampleBaseClass>.typeMap.Clear();
			HirerarchialJsonConverter<SampleBaseClass>.typeMap["sample1"] = typeof(SampleClass);

			var testClass = new TestClassWithConverter
			{
				Configuration = new SampleClass()
			};
			var json = JsonSerializer.Serialize(testClass);

			var result = JsonSerializer.Deserialize<TestClassWithConverter>(json);

			Assert.IsNotNull(result.Configuration);
			Assert.IsInstanceOfType(result.Configuration, typeof(SampleClass));
		}
	}
}
