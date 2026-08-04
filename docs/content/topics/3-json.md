# 3. KamiSama.Extensions.Json
This library is an extension for System.Text.Json as helper method. If simillar methods are added to System.Text.Json this library will be discontiued.

## 3.1. Ease of serialization and deserialization 
```csharp
// serializes an object to json string
str = obj.SerializeToJson(options);
// deserializes a json string into an object
obj = str.DeserializeFromJson<SomeTime>(options);
```
## 3.2. HirerarchialJsonConverter
It is also possible to load abstract classes from json string based on configuration. To do that, the library provides HirerarchialJsonConverter.
```csharp
public abstract class BaseClass
{
    [JsonHirerarchyDiscriminator]
    public abstract string Discriminator { get; }
}
public class ChildClass1 : BaseClass
{
    public override string Discriminator => "child1";
}
//To Register
HirerarchialJsonConverter<BaseClass>.Register<ChildClass1>("child1");
//To use:
var obj = str.DeserializeFromJson<BaseClass>(options => options.Converters.Add(new HirerarchialJsonConverter<BaseClass>());
//you can also use JsonConverterAttribute too.
```
## 3.3 Dynamic Covnerter
this special converter converts objects to dynamic one.
```csharp
var x = new
{
   X  = 1.0,
   Y = 10,
   S = "test",
   O = new 
   {
        A = 10.1
   }
};

var str = arr.SerializeToJson(options => options.Converters.Add(new DynamicObjectConverter()));
//should expect "{ "X" : 1.0, "Y": 10, "S" : "test", "O" : { "A" : 10.1 }" and vise versa
```
## 3.3 Hex Byte Array Converter
```csharp
var arr = [1, 2, 3];

var str = arr.SerializeToJson(options => options.Converters.Add(new HexByteArrayJsonConverter()));
//should expect "010203"
```
## 3.4 BigInteger Converter
```csharp
var x = new BigInteger(1);

var str = arr.SerializeToJson(options => options.Converters.Add(new BigIntegerJsonConverter()));
//should expect "\"1\""
```
## 3.5 Timespan Converter
```csharp
var x = new BigInteger(1);

var str = arr.SerializeToJson(options => options.Converters.Add(new BigIntegerJsonConverter()));
//should expect "\"1\""
```