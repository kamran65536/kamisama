# MultiProviderDbContextBuilder<TBaseContext>

<a id="multiproviderdbcontextbuilder-tbasecontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/MultiProviderDbContextBuilder.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/MultiProviderDbContextBuilder.cs#L7)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Class`

## Description

Provides the `MultiProviderDbContextBuilder<TBaseContext>` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class MultiProviderDbContextBuilder<TBaseContext>(
	IServiceCollection services,
	ConnectionStringOption connectionStringOption) : IMultiProviderDbContextBuilder<TBaseContext>
	where TBaseContext : DbContext
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/MultiProviderDbContextBuilder.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class MultiProviderDbContextBuilder<TBaseContext>(
	IServiceCollection services,
	ConnectionStringOption connectionStringOption) : IMultiProviderDbContextBuilder<TBaseContext>
	where TBaseContext : DbContext
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The `services` value passed to this member. |
| `connectionStringOption` | `ConnectionStringOption` | `-` | The `connectionStringOption` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [BaseContextType](property-basecontexttype-18.md) | Exposes the `BaseContextType` value on `MultiProviderDbContextBuilder<TBaseContext>`. Read or set it as part of configuring or using the type. |
| [ConnectionStringOption](property-connectionstringoption-14.md) | Exposes the `ConnectionStringOption` value on `MultiProviderDbContextBuilder<TBaseContext>`. Read or set it as part of configuring or using the type. |
| [MigrationHistoryTable](property-migrationhistorytable-16.md) | Exposes the `MigrationHistoryTable` value on `MultiProviderDbContextBuilder<TBaseContext>`. Read or set it as part of configuring or using the type. |
| [Services](property-services-12.md) | Exposes the `Services` value on `MultiProviderDbContextBuilder<TBaseContext>`. Read or set it as part of configuring or using the type. |

