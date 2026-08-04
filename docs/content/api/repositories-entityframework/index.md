# KamiSama.Repositories.EntityFramework

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Repository implementation and paging helpers for classic Entity Framework projects. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Repositories.EntityFramework --version 10.0.10
```

## Namespaces

- [KamiSama.Repositories.EntityFramework](kamisama-repositories-entityframework/index.md) (3 types)

## Types

- [KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>](kamisama-repositories-entityframework/kamisama-repositories-entityframework-dbrepository-tentity-tdbcontext/index.md) - Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.
- [KamiSama.Repositories.EntityFramework.DbRepository<TEntity>](kamisama-repositories-entityframework/kamisama-repositories-entityframework-dbrepository-tentity/index.md) - Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.
- [KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions](kamisama-repositories-entityframework/kamisama-repositories-entityframework-iorderedqueryableextensions/index.md) - Provides the `IOrderedQueryableExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
