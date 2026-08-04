# ConnectionStringOption

<a id="connectionstringoption"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/ConnectionStringOption.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/ConnectionStringOption.cs#L8)

Namespace: `KamiSama.Repositories`

Kind: `Class`

## Description

Configuration object for database provider and connection-string settings. Bind it from configuration when wiring repository or DbContext provider packages.

## Declaration

```csharp
public class ConnectionStringOption
```

## Example

```csharp
using KamiSama.Repositories;

var database = configuration
    .GetSection("Database")
    .Get<ConnectionStringOption>();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ConnectionString](property-connectionstring-13.md) | Exposes the `ConnectionString` value on `ConnectionStringOption`. Read or set it as part of configuring or using the type. |
| [Provider](property-provider-18.md) | the database provider used for this configuration. Use it with the surrounding package APIs when composing application code. |

