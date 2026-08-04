# IMultiProviderDbContextBuilder<TBaseContext>

<a id="imultiproviderdbcontextbuilder-tbasecontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L37)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Interface`

## Description

Defines provider-neutral DbContext registration for a base context type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IMultiProviderDbContextBuilder<TBaseContext> : IMultiProviderDbContextBuilder
	where TBaseContext : DbContext
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [WithMigrationHistoryTable](method-withmigrationhistorytable-45.md) | Sets the EF Core migrations history table used by provider registrations. Use it with the surrounding package APIs when composing application code. |

