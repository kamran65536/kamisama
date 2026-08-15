# IMultiProviderDbContextBuilder

<a id="imultiproviderdbcontextbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L11)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Interface`

## Description

Carries the services, configuration-selected provider, base context type, and migration-history table used by concrete provider registration extensions.

## Declaration

```csharp
public interface IMultiProviderDbContextBuilder
```

## Remarks

Provider extensions add scoped concrete contexts and keyed scoped aliases for `BaseContextType`.

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore;

static void Inspect(IMultiProviderDbContextBuilder builder)
{
    Console.WriteLine($"{builder.ConnectionStringOption.Provider}: {builder.BaseContextType.Name}");
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [BaseContextType](property-basecontexttype-35.md) | Gets the base DbContext type resolved by consumers. Use it with the surrounding package APIs when composing application code. |
| [ConnectionStringOption](property-connectionstringoption-23.md) | Gets the selected provider and connection string. Use it with the surrounding package APIs when composing application code. |
| [MigrationHistoryTable](property-migrationhistorytable-29.md) | Gets or sets the EF Core migrations history table used by provider registrations. Use it with the surrounding package APIs when composing application code. |
| [Services](property-services-17.md) | Gets the service collection receiving DbContext registrations. Use it with the surrounding package APIs when composing application code. |

