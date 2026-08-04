# IMultiProviderDbContextBuilder

<a id="imultiproviderdbcontextbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L10)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Interface`

## Description

Defines the provider-neutral state needed to register a DbContext for multiple database providers. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IMultiProviderDbContextBuilder
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [BaseContextType](property-basecontexttype-30.md) | Gets the base DbContext type resolved by consumers. Use it with the surrounding package APIs when composing application code. |
| [ConnectionStringOption](property-connectionstringoption-20.md) | Gets the selected provider and connection string. Use it with the surrounding package APIs when composing application code. |
| [MigrationHistoryTable](property-migrationhistorytable-25.md) | Gets or sets the EF Core migrations history table used by provider registrations. Use it with the surrounding package APIs when composing application code. |
| [Services](property-services-15.md) | Gets the service collection receiving DbContext registrations. Use it with the surrounding package APIs when composing application code. |

