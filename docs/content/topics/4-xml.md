# 4. Xml Serialization Extensions
## Index
- 4.1 Xml (De)Serialization
- 4.2 AutoXmlElementAttribute

## 4.1. Xml (De)Serialization
```csharp
// serializes an object to Xml string
str = obj.SerliazeToXml(settings => settings.Formatted = true);
// deserialize a xml string to an object
obj = str.DeserializeFromXml<SomeType>();
```

## 4.2. AutoXmlElementAttribute
this attribute indicates the Xml Serializer to find all inherited classes to be included so no manual inclusion is needed.

the class looks like this:
```csharp
public class ExampleClass
{
  [AutoXmlElement]
  public AbstractClass Example { get; set;}
}
```
you can also define it like this:
```csharp
public class EampleClass
{
  AutoXmlElement<AbstractClass> Example { get; set; }
}
```
you should first configure the XmlSerializer:
```csharp
var overrides = new XmlAttributeOverrides();

overrides.AddAutoXmlAttributes(typeof(ExampleClass), default(Assembly[]));

var serializer = new XmlSerializer(typeof(ExampleClass), overrides);
```
for usage you can either use XmlSerializer directly or as a parameter to the extension methods.
```csharp
//serializing
var str = example.SerializeToXml(serializer);
var deserialized = str.DeserializeFromXml<ExampleClass>(serializer);
```