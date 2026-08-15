---
last-checked-utc: 2026-08-14T19:23:25Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Extensions.AutoXmlAttribute
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Serialize objects to XML strings and deserialize XML strings using configurable `XmlSerializer` and `XmlWriterSettings` instances.
Build attribute-driven `XmlAttributeOverrides` for polymorphic elements and array items.

## How to use

```shell
dotnet add package KamiSama.Extensions.Xml --version 10.0.0
```

Use `KamiSama.Extensions` for string serialization and polymorphic override helpers. Polymorphic models require an `XmlAttributeOverrides` instance populated with candidate concrete types and an `XmlSerializer` constructed from those overrides.

## Example decisions

`AutoXmlAttribute` is abstract infrastructure covered by the concrete attribute and override-workflow examples, so it does not require a standalone class-level example.
