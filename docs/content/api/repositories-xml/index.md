# KamiSama.Repositories.Xml

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Read-oriented XML directory repositories that load one entity per file into memory. Version 10.0.0 has an incompatible default serializer and a broken mutation path, so use these types only for reads with an explicit per-entity serializer.

## How to use

```shell
dotnet add package KamiSama.Repositories.Xml --version 10.0.0
```

Treat both XML repository classes as read-only in version 10.0.0. Store one entity per `*.xml` file, pass a serializer for one entity because the default array serializer cannot read those files, and make the mapping return each exact file name:

```csharp
using System.Xml.Serialization;
using KamiSama.Repositories.Xml;

var serializer = new XmlSerializer(typeof(User));
using var repository = new XmlDirectoryRepository<User>(
    "data/users", user => $"{user.Id}.xml", serializer, UserIdComparer.Instance);

User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
```

Do not call add, update, or delete expecting persistence. Both implementations write to the directory path instead of mapped entity files, ignore the supplied serializer while saving, and never delete stale files; failures are raised through `SaveFailed` after in-memory changes and otherwise suppressed. A single invalid or misnamed file fails the whole load, equal entities from separate files are silently collapsed, queries are live, and locking does not coordinate multiple instances or processes.

## Namespaces

- [KamiSama.Repositories.Xml](kamisama-repositories-xml/index.md) (2 types)

## Types

- [KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>](kamisama-repositories-xml/kamisama-repositories-xml-xmldirectoryrepository-tentity/index.md) - Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence.
- [KamiSama.Repositories.Xml.XmlFileRepository<TEntity>](kamisama-repositories-xml/kamisama-repositories-xml-xmlfilerepository-tentity/index.md) - Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence.
