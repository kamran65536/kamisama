# KamiSama.Repositories.EntityFrameworkCore.Postgresql

[Back to package index](../index.md)

Version: `10.0.0`

## Description

PostgreSQL registration for KamiSama multi-provider Entity Framework Core DbContexts. It adds scoped keyed context resolution, lazy-loading proxies, migration-history configuration, and process-wide Npgsql compatibility switches.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore.Postgresql --version 10.0.0
```

**Warning:** the workspace root version is `10.0.0`, but a matching provider package may not be published. The required workspace-version command above is intentionally retained.

Register a concrete context derived from the base context after `AddMultiProviderDbContext<TBaseContext>`: `builder.AddPostgresql<PostgresqlAppDbContext>()`. This adds scoped services under the exact `postgresql` key, enables lazy-loading proxies, and applies the builder migration-history table. It also sets `Npgsql.EnableLegacyTimestampBehavior` and `Npgsql.DisableDateTimeInfinityConversions` process-wide, affecting all Npgsql use in the process.

## Namespaces

- [KamiSama.Repositories.EntityFrameworkCore.Postgresql](kamisama-repositories-entityframeworkcore-postgresql/index.md) (1 types)

## Types

- [KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions](kamisama-repositories-entityframeworkcore-postgresql/kamisama-repositories-entityframeworkcore-postgresql-multiproviderdbcontextbuilderpostgresqlextensions/index.md) - Registers a scoped PostgreSQL context under the exact `postgresql` key, enables lazy-loading proxies, configures migration history, and sets two process-wide Npgsql compatibility switches.
