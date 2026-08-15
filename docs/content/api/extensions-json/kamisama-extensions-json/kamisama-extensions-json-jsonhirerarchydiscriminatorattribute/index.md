# JsonHirerarchyDiscriminatorAttribute

<a id="jsonhirerarchydiscriminatorattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/JsonHirerarchyDiscriminatorAttribute.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonHirerarchyDiscriminatorAttribute.cs#L7)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Marks the property used by `HierarchicalJsonConverter{T}` as the polymorphic type discriminator. Apply it to exactly one public property on the base type.

## Declaration

```csharp
public class JsonHirerarchyDiscriminatorAttribute : JsonAttribute
```

## Example

```csharp
using System.Text.Json.Serialization;
using KamiSama.Extensions.Json;

public abstract record Message
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public abstract string Kind { get; }
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

