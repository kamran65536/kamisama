# GetAsync<T>

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L13)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Runs the `GetAsync<T>` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<T> GetAsync<T>(CancellationToken cancellationToken);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | The `T` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<T>` | Returns a `Task<T>` value. |

## Example

No concise standalone example is available yet.

