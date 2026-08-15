# KamiSama.Modules.Identity.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite EF Core provider registration for KamiSama.Modules.Identity.Core. Install it in an Identity host and select the required provider callback so the module can resolve its database context and run startup migrations.

## How to use

```shell
dotnet add package KamiSama.Modules.Identity.Sqlite --version 10.0.0
```

**Publication mismatch:** version `10.0.0` above is the current workspace/root documentation version, but this provider version was not published at the time of review. Use an actually published version for NuGet installation.

Install this package with Identity Core and pass `database => database.AddSqliteIdentityDbContext()` as the module's provider callback. The callback registers the internal concrete context under the exact `sqlite` key; configure `Identity:Database:provider` as `sqlite`. Core runs configured migrations during `BuildAsync`, so the process needs access to the SQLite file and its directory.

## Namespaces

- [KamiSama.Modules.Identity](kamisama-modules-identity/index.md) (1 types)

## Types

- [KamiSama.Modules.Identity.IdentitySqliteDbContextBuilderExtensions](kamisama-modules-identity/kamisama-modules-identity-identitysqlitedbcontextbuilderextensions/index.md) - Registers the internal SQLite Identity context under the shared multi-provider infrastructure's `sqlite` key.
