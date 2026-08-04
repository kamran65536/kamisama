# AddParameter

[Back to RestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/RestBuilder.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/RestBuilder.cs#L29)

Type: `KamiSama.Extensions.RestSharp.RestBuilder`

Kind: `Method`

## Description

Runs the `AddParameter` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public IRestBuilder AddParameter(string name, object? value, ParameterType parameterType, bool encode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `value` | `object?` | `-` | The `value` value passed to this member. |
| `parameterType` | `ParameterType` | `-` | The `parameterType` value passed to this member. |
| `encode` | `bool` | `-` | The `encode` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | Returns a `IRestBuilder` value. |

## Example

No concise standalone example is available yet.

