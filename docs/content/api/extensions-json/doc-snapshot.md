---
last-checked-utc: 2026-08-14T19:07:04Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

System.Text.Json convenience extensions for serialization, deserialization, dynamic JSON object graphs, and converter registration.
Includes converters for BigInteger, hexadecimal byte arrays, TimeSpan, and discriminator-based polymorphic types.

## How to use

```shell
dotnet add package KamiSama.Extensions.Json --version 10.0.0
```

Use `KamiSama.Extensions` for serialization helpers and `KamiSama.Extensions.Json` for converter types. Register converters on the `JsonSerializerOptions` instance used by the application. Polymorphic deserialization also requires a marked discriminator property and an explicit discriminator-to-derived-type registration.

## Example decisions

Every public class has a class-level example.
