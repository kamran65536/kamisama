---
last-checked-utc: 2026-08-14T22:31:50Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Extensions.RestSharp.Exceptions.InvalidResponseFromServerException
  - KamiSama.Extensions.RestSharp.Exceptions.RequestTimedOutException
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Fluent RestSharp request construction and dependency injection registration for HTTP integrations.
Build GET, POST, PUT, and DELETE requests with parameters, headers, URL segments, files, or JSON bodies, then deserialize successful responses.

## How to use

```shell
dotnet add package KamiSama.Extensions.RestSharp --version 10.0.0
```

Register an `HttpClient` before calling `AddKamiSamaRestSharp`. Inject `IRestBuilder`, call `ForServiceUrl` before configuring every request, add the required request data, and then execute the appropriate HTTP verb. The builder is scoped and stores its current request, so do not share one builder across concurrent operations.

## Example decisions

`IRestBuilder` and `ServiceCollectionExtensions` have package-specific class-level examples. `InvalidResponseFromServerException` and `RequestTimedOutException` are simple application-specific exception types and do not require class-level examples.
