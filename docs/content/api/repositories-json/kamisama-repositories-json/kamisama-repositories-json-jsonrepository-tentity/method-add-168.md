# Add

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:168](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L168)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Adds a new item in the repository; Modify to json repository is not recommended for performance issues. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void Add(TEntity item);
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

