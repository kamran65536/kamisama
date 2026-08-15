# FindByNameAsync

[Back to IFindByNameFeature<TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByNameFeature.cs#L15)

Type: `KamiSama.Chassis.Commons.Features.IFindByNameFeature<TEntityDto>`

Kind: `Method`

## Description

Finds an entity by name and returns its &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The entity name to find. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO for the matching entity. |

## Example

No concise standalone example is available yet.

