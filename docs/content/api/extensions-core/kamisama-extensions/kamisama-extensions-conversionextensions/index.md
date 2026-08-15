# ConversionExtensions

<a id="conversionextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/ConversionExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ConversionExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides fallback-based conversion of objects to runtime or generic target types. Failed conversions return the caller-provided default value instead of throwing.

## Declaration

```csharp
public static class ConversionExtensions
```

## Example

```csharp
object value = "42";
int number = value.ConvertTo(-1);       // 42
int fallback = "invalid".ConvertTo(-1); // -1
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertTo](method-convertto-16.md) | Converts an object to the specified runtime type, returning a fallback when conversion fails. Use it with the surrounding package APIs when composing application code. |
| [ConvertTo<T>](method-convertto-t-43.md) | Converts an object to the specified generic type, returning a fallback when conversion fails. Use it with the surrounding package APIs when composing application code. |

