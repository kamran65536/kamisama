# FindByIdAsync

[Back to IFindByIdFeature<TEntityDto, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs#L12)

Type: `KamiSama.Chassis.Commons.Features.IFindByIdFeature<TEntityDto, TKey>`

Kind: `Method`

## Description

Finds an &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; by it&apos;s id. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

No concise standalone example is available yet.

