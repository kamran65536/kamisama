# DynamicObjectConverter

<a id="dynamicobjectconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/DynamicObjectConverter.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/DynamicObjectConverter.cs#L6)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

dynamic object converter is used to covert json elements into object and vise versa. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class DynamicObjectConverter : JsonConverter<object>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-12.md) | Runs the `Read` operation on `DynamicObjectConverter`. Use it when your code needs this specific behavior from the package. |
| [Write](method-write-9.md) | Runs the `Write` operation on `DynamicObjectConverter`. Use it when your code needs this specific behavior from the package. |

