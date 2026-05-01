# `KamiSama.Extensions`

## `KamiSama.Extensions`

### `ArrayExtensions`
Array padding and trimming helpers for raw arrays.

### `Pad<TArrayItem>(this TArrayItem[] arr, Func<int, bool> paddingCriteria, TArrayItem paddingValue = default!)`
Grows an array until the predicate on the target length returns `true`.

```csharp
using KamiSama.Extensions;

var block = new byte[] { 1, 2, 3 }.Pad(len => len % 8 == 0, 0);
```

### `Pad<TArrayItem>(this TArrayItem[] arr, int newSize, TArrayItem paddingValue = default!)`
Pads to an explicit size. Throws if `newSize` is smaller than the current length.

```csharp
using KamiSama.Extensions;

var padded = new[] { "A", "B" }.Pad(4, "-");
```

### `TrimEnd<TArrayItem>(this TArrayItem[] arr, Func<TArrayItem, bool> trimmingCriteria)`
Removes trailing items while the predicate matches.

```csharp
using KamiSama.Extensions;

var clean = new[] { 1, 2, 0, 0 }.TrimEnd(x => x == 0);
```

### `TrimEnd<TArrayItem>(this TArrayItem[] arr, TArrayItem trimmingItem)`
Removes trailing occurrences of a specific value.

```csharp
using KamiSama.Extensions;

var clean = new[] { "a", "b", "" }.TrimEnd("");
```

## `KamiSama.Extensions`

### `ByteArrayExtensions`
Byte-array conversion helpers for hex, text, and Base64.

### `ToHex(this byte[] arr, string? separator = null)`
Formats bytes as uppercase hexadecimal text.

```csharp
using KamiSama.Extensions;

var hex = new byte[] { 0x0A, 0xFF }.ToHex();
```

### `GetString(this byte[] arr, Encoding? encoding = null)`
Decodes bytes using UTF-8 by default.

```csharp
using KamiSama.Extensions;
using System.Text;

var text = "Kami".ToBytes(Encoding.UTF8).GetString();
```

### `ToBase64(this byte[] arr)`
Converts bytes to a Base64 string.

```csharp
using KamiSama.Extensions;

var b64 = new byte[] { 1, 2, 3 }.ToBase64();
```

## `KamiSama.Extensions`

### `StringExtensions`
String-to-byte and encoded-text parsing helpers.

### `ToBytes(this string? str, Encoding? encoding = null)`
Converts text to bytes using UTF-8 by default.

```csharp
using KamiSama.Extensions;

var bytes = "hello".ToBytes();
```

### `FromHex(this string? hex)`
Parses hex text while tolerating whitespace and odd-length values.

```csharp
using KamiSama.Extensions;

var bytes = "0A FF".FromHex();
```

### `FromBase64(this string base64)`
Parses Base64 text into raw bytes.

```csharp
using KamiSama.Extensions;

var bytes = "AQID".FromBase64();
```

## `KamiSama.Extensions`

### `ConversionExtensions`
Safe object conversion helpers that fall back to a default value.

### `ConvertTo(this object? obj, Type type, object? defaultValue = null)`
Converts an object with support for nullable targets and enums.

```csharp
using KamiSama.Extensions;

object? value = "42";
var result = (int?)value.ConvertTo(typeof(int), 0);
```

### `ConvertTo<T>(this object? obj, T? defaultValue = default)`
Generic wrapper around `ConvertTo(Type, ...)`.

```csharp
using KamiSama.Extensions;

object? value = "true";
var flag = value.ConvertTo(false);
```

## `KamiSama.Extensions`

### `CryptographyExtensions`
Symmetric encryption, decryption, and MAC-style signing helpers over `byte[]`.

### `Encrypt(this byte[] data, SymmetricAlgorithm algorithm)`
Encrypts using a configured symmetric algorithm instance.

### `Encrypt(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)`
Creates and configures the algorithm for one-off encryption.

### `Decrypt(this byte[] cipher, SymmetricAlgorithm algorithm)`
Decrypts using a configured symmetric algorithm instance.

### `Decrypt(this byte[] cipher, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros)`
Creates and configures the algorithm for one-off decryption.

### `Sign(this byte[] data, SymmetricAlgorithm algorithm)`
Returns the final block of CBC-style encryption output as a MAC-like signature.

### `Sign(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros)`
Configures the algorithm then computes the signature.

### `DesEncrypt`, `DesDecrypt`, `DesSign`
DES convenience wrappers.

### `TripleDesEncrypt`, `TripleDesDecrypt`, `TripleDesSign`
3DES convenience wrappers.

### `AesEncrypt`, `AesDecrypt`, `AesSign`
AES convenience wrappers.

### `RsaEncrypt(this byte[] data, string xmlKey, RSAEncryptionPadding padding)`
Encrypts with an RSA XML key.

### `RsaDecrypt(this byte[] cipher, string xmlKey, RSAEncryptionPadding padding)`
Decrypts with an RSA XML key.

```csharp
using KamiSama.Extensions;
using System.Security.Cryptography;

var key = "00112233445566778899AABBCCDDEEFF".FromHex();
var iv = "0102030405060708090A0B0C0D0E0F10".FromHex();
var cipher = "secret".ToBytes().AesEncrypt(key, iv, PaddingMode.PKCS7);
var plain = cipher.AesDecrypt(key, iv, PaddingMode.PKCS7).GetString().TrimEnd('\0');
```

## `KamiSama.Extensions`

### `HashExtensions`
Hashing helpers over `byte[]` and `string`.

### `ComputeHash(this byte[] data, HashAlgorithm algorithm)`
Computes a hash using a supplied algorithm.

### `ComputeHashHex(this byte[] data, HashAlgorithm algorithm)`
Computes a hash and formats it as hex.

### `ComputeHash(this string data, HashAlgorithm algorithm, Encoding? encoding = null)`
Hashes a string using UTF-8 by default.

### `ComputeHashHex(this string data, HashAlgorithm algorithm, Encoding? encoding = null)`
Hashes a string and returns hex.

### `GetMd5`, `GetMd5Hex`, `GetSha1`, `GetSha1Hex`
Convenience wrappers for MD5 and SHA1 on both `byte[]` and `string`.

```csharp
using KamiSama.Extensions;

var digest = "payload".GetSha1Hex();
```

## `KamiSama.Extensions`

### `PersianDateTimeExtensions`
Formatting and parsing helpers backed by `PersianCalendar`.

### `ToPersianString(this DateTime dateTime)`
Formats a `DateTime` using the default Persian date/time format.

### `ToPersianString(this DateTime dateTime, string format)`
Formats with a custom Persian format string.

### `ParseAsPersianDateTime(this string str)`
Parses Persian date text.

### `ParseExactAsPersianDateTime(this string str, string format)`
Parses Persian date text with an exact format.

### `TryParseAsPersianDateTime(this string str, out DateTime dateTime)`
Attempts Persian parsing with the default format info.

### `TryParseExactAsPersianDateTime(this string str, string format, out DateTime dateTime)`
Attempts Persian parsing with an exact format.

```csharp
using KamiSama.Extensions;

var text = DateTime.UtcNow.ToPersianString("yyyy/MM/dd");
var value = "1403/01/01".ParseAsPersianDateTime();
```

## `KamiSama.Extensions`

### `QueueExtensions`
Adds a safe dequeue fallback for empty queues.

### `DequeueOrDefault<TItem>(this Queue<TItem> queue, TItem? defaultValue = default)`
Returns the dequeued item or the supplied default.

```csharp
using KamiSama.Extensions;

var q = new Queue<int>();
var item = q.DequeueOrDefault(-1);
```

## `KamiSama.Extensions`

### `StreamExtensions`
Ensures exact byte reads from streams.

### `ReadExact(this Stream stream, int length, int maxTries = int.MaxValue)`
Reads exactly `length` bytes or throws.

### `ReadExactAsync(this Stream stream, int length, CancellationToken cancellationToken)`
Async version of exact-length reads.

```csharp
using KamiSama.Extensions;

using var stream = new MemoryStream(new byte[] { 1, 2, 3, 4 });
var block = await stream.ReadExactAsync(4, CancellationToken.None);
```

## `KamiSama.Extensions`

### `TimeSpanExtensions`
Fluent `int` and `double` to `TimeSpan` helpers.

### `Milliseconds`, `Seconds`, `Minutes`, `Hours`, `Days`
Available for both `double` and `int`.

```csharp
using KamiSama.Extensions;

var delay = 5.Seconds() + 250.Milliseconds();
```

# `KamiSama.Extensions.Paging`

## `KamiSama.Extensions.Paging`

### `SearchModel`
Primary paging/search DTO used across repositories and features.

### `All`
Represents an all-items query by using `Page = 0` and `PageSize = 0`.

### `FromPage(int pageNo, int pageSize)`
Factory for standard paged search values.

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.FromPage(1, 20);
```

## `KamiSama.Extensions.Paging`

### `PagedResult<T>`
Paged DTO carrying total item count and the current page of items.

### `Empty`
An empty page result.

### `ConvertTo<TOtherType>(Func<T, TOtherType> convertFunc)`
Maps items synchronously while preserving total count.

### `ConvertToAsync<TOtherType>(Func<T, CancellationToken, Task<TOtherType>> convertFunc, CancellationToken cancellationToken)`
Maps items asynchronously while preserving total count.

```csharp
using KamiSama.Extensions.Paging;

var page = new PagedResult<int>(3, [1, 2, 3]);
var textPage = page.ConvertTo(x => x.ToString());
```

## `KamiSama.Extensions`

### `IQueryableExtensions`
Turns an in-memory or LINQ query into a `PagedResult<T>`.

### `MakePaged<T>(this IQueryable<T> query, SearchModel searchModel)`
Counts the query and slices it using `Page` and `PageSize`. A page size of `0` returns all items.

```csharp
using KamiSama.Extensions;
using KamiSama.Extensions.Paging;

var page = new[] { 1, 2, 3, 4 }.AsQueryable().MakePaged(SearchModel.FromPage(1, 2));
```

# `KamiSama.Extensions.Json`

## `KamiSama.Extensions`

### `JsonSerializationExtensions`
System.Text.Json helpers plus utility converters.

### `SerializeToJson(this object obj, JsonSerializerOptions? options = null)`
Serializes with explicit options.

### `SerializeToJson(this object? obj, Action<JsonSerializerOptions>? configure)`
Serializes after applying an options configuration delegate.

### `DeserializeFromJson<TObject>(this string str, JsonSerializerOptions? options = null)`
Deserializes JSON to a concrete type.

### `DeserializeFromJson<TObject>(this string str, Action<JsonSerializerOptions>? configure)`
Deserializes after configuring options inline.

### `ConvertJsonToDynamicObject(this JsonElement element)`
Converts a JSON element to `ExpandoObject`, arrays, strings, numbers, booleans, or `null`.

### `ConvertJsonToDynamicObject(this string jsonStr, JsonDocumentOptions options = default)`
Parses JSON text to dynamic object form.

### `ConvertJsonToDynamicObject(this string jsonStr, Action<JsonDocumentOptions>? config)`
Configures parse options inline.

### `AddHierarchicalConverter<T>(this JsonSerializerOptions options)`
Adds `HierarchicalJsonConverter<T>`.

### `AddTimeSpanJsonConverter(this JsonSerializerOptions options)`
Adds `TimeSpanJsonConverter`.

### `AddHexByteConverter(this JsonSerializerOptions options)`
Adds `HexByteArrayJsonConverter`.

```csharp
using KamiSama.Extensions;

var json = new { Name = "Kami", Timeout = 5.Seconds() }
    .SerializeToJson(opt => opt.AddTimeSpanJsonConverter());
```

## `KamiSama.Extensions.Json`

### `BigIntegerJsonConverter`
Serializes `BigInteger` as a string and accepts both string and number tokens on read.

### `Read`
Parses the token into `BigInteger`.

### `Write`
Writes the value as text.

```csharp
using KamiSama.Extensions.Json;
using System.Text.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());
```

## `KamiSama.Extensions.Json`

### `DynamicObjectConverter`
Converts arbitrary JSON into dynamic object graphs based on runtime shape.

### `Write`
Serializes runtime values using their real runtime type.

### `Read`
Builds dynamic object graphs from JSON input.

```csharp
using KamiSama.Extensions.Json;
using System.Text.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new DynamicObjectConverter());
```

## `KamiSama.Extensions.Json`

### `HexByteArrayJsonConverter`
Reads and writes `byte[]` values as hexadecimal strings.

### `Read`
Parses a hex string or `null`.

### `Write`
Writes hex text or JSON null.

```csharp
using KamiSama.Extensions;
using System.Text.Json;

var options = new JsonSerializerOptions().AddHexByteConverter();
```

## `KamiSama.Extensions.Json`

### `JsonHirerarchyDiscriminatorAttribute`
Marks the discriminator property used by `HierarchicalJsonConverter<T>`.

No public methods.

```csharp
using KamiSama.Extensions.Json;
using System.Text.Json.Serialization;

public abstract class Shape
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";
}
```

## `KamiSama.Extensions.Json`

### `HierarchicalJsonConverter<T>`
Polymorphic converter keyed by a discriminator property decorated with `JsonHirerarchyDiscriminatorAttribute`.

### `Register<TChild>(string discriminatorKeyValue)`
Maps a discriminator string to a derived type.

### `Register<TChild>()`
Creates a default `TChild` instance and reads its discriminator value.

### `Register(string discriminatorKeyValue, Type type)`
Maps a discriminator string to a runtime type.

### `Read`
Resolves the discriminator and deserializes to the registered derived type.

### `Write`
Serializes using the runtime type.

```csharp
using KamiSama.Extensions;
using KamiSama.Extensions.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public abstract class Shape
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";
}

public sealed class Circle : Shape
{
    public Circle() => Kind = "circle";
    public double Radius { get; set; }
}

HierarchicalJsonConverter<Shape>.Register<Circle>();
var options = new JsonSerializerOptions().AddHierarchicalConverter<Shape>();
```

## `KamiSama.Extensions.Json`

### `TimeSpanJsonConverter`
Serializes `TimeSpan` as its string form and parses from strings.

### `Read`
Parses `TimeSpan` text.

### `Write`
Writes `TimeSpan.ToString()`.

```csharp
using KamiSama.Extensions;
using System.Text.Json;

var options = new JsonSerializerOptions().AddTimeSpanJsonConverter();
```

# `KamiSama.Extensions` XML

## `KamiSama.Extensions`

### `AutoXmlAttribute`
Base attribute for XML override discovery.

### `VisitType`
Adds overrides when applied at the type level.

### `VisitProperty`
Adds overrides when applied to a property.

### `VisitField`
Adds overrides when applied to a field.

```csharp
using KamiSama.Extensions;

// Used indirectly through derived attributes such as AutoXmlElementAttribute.
```

## `KamiSama.Extensions`

### `AutoXmlArrayItemAttribute`
Adds `XmlArrayItemAttribute` entries for derived array element types.

### `VisitProperty`
Registers derived array item types for a property.

### `VisitField`
Registers derived array item types for a field.

```csharp
using KamiSama.Extensions;

public abstract class Animal {}
public sealed class Cat : Animal {}

public class Zoo
{
    [AutoXmlArrayItem]
    public Animal[] Animals { get; set; } = [];
}
```

## `KamiSama.Extensions`

### `AutoXmlElement<TValue>`
Wrapper that keeps a stable outer element name while allowing polymorphic inner values.

No public methods beyond implicit conversion and object equality overrides.

```csharp
using KamiSama.Extensions;

AutoXmlElement<string> element = "value";
```

## `KamiSama.Extensions`

### `AutoXmlElementAttribute`
Adds `XmlElementAttribute` entries for derived property or field types.

### `VisitProperty`
Registers derived element types for a property.

### `VisitField`
Registers derived element types for a field.

```csharp
using KamiSama.Extensions;

public abstract class Animal {}
public sealed class Cat : Animal {}

public class Owner
{
    [AutoXmlElement]
    public Animal Pet { get; set; } = new Cat();
}
```

## `KamiSama.Extensions`

### `XmlAttributeOverridesExtensions`
Discovers `AutoXml*` attributes recursively and populates `XmlAttributeOverrides`.

### `AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Assembly[]? assemblies)`
Scans assemblies for related types and applies overrides.

### `AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Type[] allTypes)`
Applies overrides from a precomputed type list.

```csharp
using KamiSama.Extensions;
using System.Reflection;
using System.Xml.Serialization;

var overrides = new XmlAttributeOverrides();
overrides.AddAutoXmlAttributes(typeof(Owner), [Assembly.GetExecutingAssembly()]);
```

## `KamiSama.Extensions`

### `XmlSerializationExtensions`
XML string serialization helpers.

### `SerializeToXml(this object obj, Action<XmlWriterSettings>? settingsAction = null, XmlSerializer? serializer = null)`
Serializes an object using `XmlSerializer`.

### `DeserializeFromXml<TObject>(this string str, XmlSerializer? serializer = null)`
Deserializes XML text to a typed object.

```csharp
using KamiSama.Extensions;

var xml = new { Name = "Kami" }.SerializeToXml();
```
