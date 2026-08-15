---
last-checked-utc: 2026-08-14T23:07:51Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Chassis.HttpExceptions.BadRequestException
  - KamiSama.Chassis.HttpExceptions.ConflictException
  - KamiSama.Chassis.HttpExceptions.ForbiddenException
  - KamiSama.Chassis.HttpExceptions.GoneException
  - KamiSama.Chassis.HttpExceptions.InvalidOperationHttpException
  - KamiSama.Chassis.HttpExceptions.NotImplementedHttpException
  - KamiSama.Chassis.HttpExceptions.NotSupportedHttpException
  - KamiSama.Chassis.HttpExceptions.PaymentRequiredException
  - KamiSama.Chassis.HttpExceptions.UnAuthorizedException
  - KamiSama.Chassis.HttpExceptions.UnProcessableEntityException
---

# Documentation Snapshot

The package description, public and protected API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

HTTP-oriented exception types with status codes, localization keys, and extra problem details.
Use these exceptions to keep application errors consistent across ASP.NET Core APIs.

## How to use

```shell
dotnet add package KamiSama.Chassis.HttpExceptions --version 10.0.0
```

Throw the most specific exception from application code and let an API-boundary adapter convert it. These types carry metadata only and do not write an HTTP response. Message keys are also fallback composite-format strings, and invalid formats are returned unchanged by `TryFormatString`.

`ExtendedProperties` is available for custom adapters, but the current `KamiSamaProblemDetailsProvider` does not copy it. `GoneException` currently reports status 401 rather than the conventional 410; the documentation records that runtime behavior without changing it.

## Example decisions

`HttpExceptionBase`, `AlreadyExistsException<TEntity>`, `NotFoundException<TEntity>`, and `ServiceUnavailableException` have full-name-matched class examples. The ten listed fixed-status wrappers differ primarily by status and constructor forwarding, so they are exempt from separate class-level examples.
