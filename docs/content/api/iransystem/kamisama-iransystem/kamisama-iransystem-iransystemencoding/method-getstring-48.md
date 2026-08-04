# GetString

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L48)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Runs the `GetString` operation on `IranSystemEncoding`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public override string GetString(byte[] bytes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `bytes` | `byte[]` | `-` | The `bytes` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var arr = "012"u8.ToArray();

var str = arr.GetString();
```

