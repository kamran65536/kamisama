# ConnectionStringOption

<a id="connectionstringoption"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/ConnectionStringOption.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/ConnectionStringOption.cs#L8)

Namespace: `KamiSama.Repositories`

Kind: `Class`

## Description

Contains the provider identifier and connection string bound from configuration. Provider packages decide which identifiers they accept and how the connection string is used.

## Declaration

```csharp
public class ConnectionStringOption
```

## Example

```csharp
using KamiSama.Repositories;

var database = new ConnectionStringOption
{
    Provider = "sqlite",
    ConnectionString = "Data Source=app.db"
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ConnectionString](property-connectionstring-13.md) | Gets or sets the database connection string bound from the `connection-string` configuration key. |
| [Provider](property-provider-18.md) | Gets or sets the provider identifier bound from the `provider` configuration key; a provider package defines accepted values. |

