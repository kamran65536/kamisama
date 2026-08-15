# KamiSama.Repositories.Xml

[Back to KamiSama.Repositories.Xml](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [XmlDirectoryRepository<TEntity>](kamisama-repositories-xml-xmldirectoryrepository-tentity/index.md) | Class | Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L26) |
| [XmlFileRepository<TEntity>](kamisama-repositories-xml-xmlfilerepository-tentity/index.md) | Class | Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L26) |
