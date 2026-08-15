---
last-checked-utc: 2026-08-14T23:59:09Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public and protected API summaries, substitute and service lifecycles, disposal limitations, and example coverage were reviewed against the source at the recorded root version.

## Description

A DI-first test builder that registers configured substitutes and creates NSubstitute doubles for missing constructor dependencies.
Use it to build focused service tests through a scoped Microsoft.Extensions.DependencyInjection container.

## How to use

```shell
dotnet add package KamiSama.Testing.NSubstitute --version 10.0.0
```

Derive a focused builder, register scenario substitutes and options, call `BuildService<TService>`, and only then use `For<T>`. The generator-owned How-to contains the complete builder pattern.

`BuildService<TService>` inspects only the first public constructor returned by reflection and substitutes unresolved parameters only for that constructor. NSubstitute proxy limitations still apply. Scoped and transient helpers capture and repeatedly return one substitute instead of creating instances with normal DI lifetime semantics. Registrations accumulate across builds. Temporary and final providers, temporary and final scopes, replaced scopes, and resolved disposable services are not disposed by the builder; do not use it when disposal behavior is under test.

## Example decisions

`TesterBuilderBase` has a complete full-name-matched class example covering options, a configured substitute, target construction, and generated-dependency resolution. Every public member has an exact full-name-and-member example; no class is exempt.
