# PutAsync<T>

[Back to RestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/RestBuilder.cs:72](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/RestBuilder.cs#L72)

Type: `KamiSama.Extensions.RestSharp.RestBuilder`

Kind: `Method`

## Description

Runs the `PutAsync<T>` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<T> PutAsync<T>(CancellationToken cancellationToken);
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

