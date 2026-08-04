# Add

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:191](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L191)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Runs the `Add` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

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

