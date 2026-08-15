# ConnectionString

[Back to ConnectionStringOption](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/ConnectionStringOption.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/ConnectionStringOption.cs#L13)

Type: `KamiSama.Repositories.ConnectionStringOption`

Kind: `Property`

## Description

Gets or sets the database connection string bound from the `connection-string` configuration key.

## Declaration

```csharp
public string? ConnectionString { get; set; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `string?` value. |

## Example

```csharp
var options = new ConnectionStringOption
{
    Provider = "sqlite",
    ConnectionString = "Data Source=app.db"
};
```

