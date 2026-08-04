# AddParameter

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L7)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Runs the `AddParameter` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
IRestBuilder AddParameter(string name, object? value, ParameterType parameterType = ParameterType.GetOrPost, bool encode = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `value` | `object?` | `-` | The `value` value passed to this member. |
| `parameterType` | `ParameterType` | `ParameterType.GetOrPost` | The `parameterType` value passed to this member. |
| `encode` | `bool` | `true` | The `encode` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | Returns a `IRestBuilder` value. |

## Example

No concise standalone example is available yet.

