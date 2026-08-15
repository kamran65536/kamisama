---
last-checked-utc: 2026-08-14T19:29:10Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Automatically register attributed service implementations with Microsoft.Extensions.DependencyInjection by scanning selected assemblies.
Choose transient, scoped, or singleton lifetimes, keyed or unkeyed registrations, explicit or inferred service types, and single or multiple registrations.

## How to use

```shell
dotnet add package KamiSama.Extensions.DependencyInjection --version 10.0.0
```

Decorate each implementation with the appropriate registration attribute, then scan its assembly during service configuration:

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;

services.AutoAddDependenciesFrom<Program>();
```

## Example decisions

Every public class has a class-level example.
