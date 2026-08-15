# HierarchicalJsonConverter<T>

<a id="hierarchicaljsonconverter-t"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L10)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Deserializes instances of a base type as registered derived types selected by a discriminator property. Mark the base type&apos;s discriminator property and register every supported discriminator value before deserialization.

## Declaration

```csharp
public class HierarchicalJsonConverter<T> : JsonConverter<T>
		where T : class
```

## Example

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;
using KamiSama.Extensions;
using KamiSama.Extensions.Json;

public abstract record Contact
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public abstract string Kind { get; }
}

public sealed record EmailContact(string Address) : Contact
{
    public override string Kind => "email";
}

HierarchicalJsonConverter<Contact>.Register<EmailContact>("email");
var options = new JsonSerializerOptions().AddHierarchicalConverter<Contact>();
Contact? contact = JsonSerializer.Deserialize<Contact>("{\"kind\":\"email\",\"address\":\"dev@example.com\"}", options);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-75.md) | Deserializes a JSON object as the derived type registered for its discriminator value. Use it with the surrounding package APIs when composing application code. |
| [Register](method-register-41.md) | Associates a discriminator value with the specified runtime type. Use it with the surrounding package APIs when composing application code. |
| [Register<TChild>](method-register-tchild-25.md) | Associates a discriminator value with the derived type &lt;typeparamref name=&quot;TChild&quot;/&gt;. Use it with the surrounding package APIs when composing application code. |
| [Register<TChild>](method-register-tchild-31.md) | Registers &lt;typeparamref name=&quot;TChild&quot;/&gt; using the discriminator value obtained from a newly constructed instance. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-66.md) | Serializes the value using its runtime type. Use it with the surrounding package APIs when composing application code. |

