# Add

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L16)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Adds a new item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
void Add(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The `item` value passed to this member. |

## Example

```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

var x = new BigInteger(100);
var result = x.SerializeToJson(options);
```

