# FindByNameAsync

[Back to IFindByNameFeature<TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs#L12)

Type: `KamiSama.Chassis.Commons.Features.IFindByNameFeature<TEntityDto>`

Kind: `Method`

## Description

Finds an &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; by it&apos;s name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

No concise standalone example is available yet.

