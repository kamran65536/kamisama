# Provider

[Back to ConnectionStringOption](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/ConnectionStringOption.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/ConnectionStringOption.cs#L18)

Type: `KamiSama.Repositories.ConnectionStringOption`

Kind: `Property`

## Description

Gets or sets the provider identifier bound from the `provider` configuration key; a provider package defines accepted values.

## Declaration

```csharp
public string? Provider { get; set; }
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

