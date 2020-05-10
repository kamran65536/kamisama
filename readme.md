# KamiSama Extension Libraries
## Introduction
KamiSama.Extension libraries are set of suger codes and helper methods for most common usages.
Here is the list of libraries:
- [KamiSama.Extensions.Core](#1-kamisamaextensionscore)
- [KamiSama.Extensions.DependencyInjection](#2-kamisamaextensionsdependencyinjection)
- [KamiSama.Extensions.Json](#3-kamisamaextensionsjson)
- [KamiSama.Extensions.Repositories libraries](#4-kamisamarepositories-libraries)
## 1. KamiSama.Extensions.Core
The library includes some helper methods for string, hexadecimal, byte array, ....
Here is some examples of the helper methods:
- [KamiSama Extension Libraries](#kamisama-extension-libraries)
  - [Introduction](#introduction)
  - [1. KamiSama.Extensions.Core](#1-kamisamaextensionscore)
    - [1.1. Array Extensions](#11-array-extensions)
    - [1.2. Byte Array Extensions](#12-byte-array-extensions)
    - [1.3. Conversion Extensions](#13-conversion-extensions)
    - [1.4 Cryptography Extensions](#14-cryptography-extensions)
    - [1.5 Hashing Extensions](#15-hashing-extensions)
    - [1.6 Persian DateTime Extensions](#16-persian-datetime-extensions)
  - [1.7 Queue Extensions](#17-queue-extensions)
  - [1.8 Stream Extensions](#18-stream-extensions)
  - [1.9 String Extensions](#19-string-extensions)
  - [1.10 TimeSpan Extensions](#110-timespan-extensions)
  - [1.11 Xml Serialization Extensions](#111-xml-serialization-extensions)
- [2. KamiSama.Extensions.DependencyInjection](#2-kamisamaextensionsdependencyinjection)
- [3. KamiSama.Extensions.Json](#3-kamisamaextensionsjson)
  - [3.1 HirerarchialJsonConverter](#31-hirerarchialjsonconverter)
- [4. KamiSama.Repositories Libraries](#4-kamisamarepositories-libraries)
### 1.1. Array Extensions
```csharp
// pads an array until to total length becomes multiplies of 8
arr = arr.Pad(len => len % 8 == 0, 0x0f);
// pads an array to new size
arr = arr.Pad(32);
// Trims all zero and one bytes from end of an array
arr = arr.TrimEnd(x => (x == 0x00) || (x == 0x01));
// Trims all zero bytes from end of an array
arr = arr.TrimEnd(0x00);
```
### 1.2. Byte Array Extensions
```csharp
// converts an byte array to hexadecimal string
str = new byte[] { 0x01, 0x02, 0x03 }.ToHex(); // would be 010203
// converts an byte array to string using UTF8
str = arr.GetString(Encoding.UTF8);
// converts an byte array to base 64
str = arr.ToBase64();
```
### 1.3. Conversion Extensions
```csharp
// converts an object to the desired type
x = "12".ConvertTo(typeof(int));
// converts an object to an generic type
y = "13".ConvertTo<int>();
```
### 1.4 Cryptography Extensions
```csharp
// encrypts using DES algorithm
desCipher = arr.DesEncrypt(key, new byte[8], CipherMode.CBC, PaddingMode.None);
// decrypts using DES algorithm
arr =  desCipher.DesDecrypt(key, new byte[8], CipherMode.CBC, PaddingMode.None);
// signs (MAC) for data
sign = arr.Sign(key, new byte[8], PaddingMode.None);
```
The same methods exist for TripleDES (3DES), AES.
The library also support RSA cryptography but it is slightly different:
```csharp
// data encryption:
rsaCipher = arr.RsaEncrypt(xmlKey, RSAEncryptionPadding.Pkcs1);
// cipher decryption:
arr = rsaCipher.RsaDecrypt(xmlKey, RSAEncryptionPadding.Pkcs1);
```
Please read Microsoft Cryptography documentation for how to generate xml key.
### 1.5 Hashing Extensions
```csharp
// generates MD5 hash
md5 = arr.GetMd5();
// generates MD5 hash and convert it to hex
md5Hex = arr.GetMd5Hex();
// converts an string to byte array and then generates md5
md5 = str.GetMd5();
// converts an string to byte array and then generates md5 
// and then converts it to hex
md5Hex = arr.GetMd5Hex(Encoding.UTF8);
```
The same methods is defined for SHA1 hash.
### 1.6 Persian DateTime Extensions
```csharp
// converts to an persian date time using Persian Calendar
str = dateTime.ToPersianString();
// converts to an persian date time with formatting
str = dateTime.ToPersianString("yyyy/MM/dd HH:mm:ss");
// parses an string as persian date
dateTime = str.ParseAsPersianDateTime();
// parses using exact format given
dateTime = str.ParseAsExactPersianDateTime("yyyy/MM/dd HH:mm:ss");
// tries to parse methods
success = str.TryParseAsPersianDateTime(out dateTime);
success = str.TryParseExactAsPersianDateTime(out dateTime, "yyyy/MM/dd HH:mm:ss");
```
## 1.7 Queue Extensions
```csharp
// dequeues an queue if queue is not empty else returns default item
item = queue.DequeueOrDefault(defaultItem);
```
## 1.8 Stream Extensions
```csharp
// the output is allways an array of size desired length; otherwise it throws an Exception
arr = stream.ReadExact(length: 10, maxTries: 100);
arr = await stream.ReadExactAsync(length: 10, maxTries: 100);
```
## 1.9 String Extensions
```csharp
// converts a string to byte array using given encoding
arr = str.ToBytes(Encoding.UTF8);
// converts hexadecimal string to byte array
arr = hexStr.FromHex();
// converts base64 string to byte arr
arr = base64Str.FromBase64();
```
## 1.10 TimeSpan Extensions
```csharp
    // creates an TimeSpan from milliseconds
    ts = (10.3).Milliseconds();
    // creates an TimeSpan from seconds
    ts = (11.5).Seconds();
    // creates an TimeSpan from minutes
    ts = 5.Minutes();
    // creates an TimeSpan from hours
    ts = 127.Hours();
    // creates an TimeSpan from days
    ts = 2.Days();
```
## 1.11 Xml Serialization Extensions
```csharp
// serializes an object to Xml string
str = obj.SerliazeToXml(settings => settings.Formatted = true);
// deserialize a xml string to an object
obj = str.DeserializeFromXml<SomeType>();
```
# 2. KamiSama.Extensions.DependencyInjection
This library is an simple extension on Microsoft.Extensions.DependencyInjection library. Currently this library only includes named services, but new features will be added if needed. Here is a sample code:
```csharp
// adds a singleton with name instance1
services.AddSingleton<IMyInterface, SomeType>("instance1");
// adds a transient with name instance2
services.AddTransient<IMyInterface, AnotherType>("instance2");
// adds a scoped with name instanc3
services.AddScoped<IMyInterface, ScopedType>("instance3");
```
Note that you cannot use this feature for automatic injection. The only way to use it is through IServiceProvider
```csharp
instance = serviceProvider.GetService("instance2");
```
# 3. KamiSama.Extensions.Json
This library is an extension for System.Text.Json as helper method. If simillar methods are added to System.Text.Json this library will be discontiued.
```csharp
// serializes an object to json string
str = obj.SerializeToJson(options);
// deserializes a json string into an object
obj = str.DeserializeFromJson(options);
```
## 3.1 HirerarchialJsonConverter
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
var obj = str.DeserializeFromJson(options => options.Converters.Add(new HirerarchialJsonConverter<BaseClass>());
//you can also use JsonConverterAttribute too.
```

# 4. KamiSama.Repositories Libraries
Please see [this document](./KamiSama.Repositories-readme.md).