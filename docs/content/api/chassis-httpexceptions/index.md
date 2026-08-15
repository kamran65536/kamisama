# KamiSama.Chassis.HttpExceptions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

HTTP-oriented exception types with status codes, localization keys, and extra problem details. Use these exceptions to keep application errors consistent across ASP.NET Core APIs.

## How to use

```shell
dotnet add package KamiSama.Chassis.HttpExceptions --version 10.0.0
```

Throw an HTTP exception from application or feature code, then let an API-boundary adapter translate its status and localization metadata into a response:

```csharp
using KamiSama.Chassis.HttpExceptions;

Product product = await repository.FindByIdAsync(id, cancellationToken)
    ?? throw new NotFoundException<Product>(id, nameof(id));
```

These exceptions only carry metadata; they do not write HTTP responses. `ExceptionLocalizationKey` and `ExceptionLocalizationArguments` are intended for a localizing adapter. `ExtendedProperties` is available to adapters, but the current `KamiSamaProblemDetailsProvider` does not copy it. `GoneException` currently reports 401 rather than 410.

## Namespaces

- [KamiSama.Chassis.HttpExceptions](kamisama-chassis-httpexceptions/index.md) (16 types)

## Types

- [KamiSama.Chassis.HttpExceptions.AlreadyExistsException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-alreadyexistsexception/index.md) - Represents a conflict in which an entity with the supplied key already exists. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.AlreadyExistsException<TEntity>](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-alreadyexistsexception-tentity/index.md) - Represents a conflict in which an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; already exists. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.BadRequestException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-badrequestexception/index.md) - Represents a client request that cannot be processed and should be reported with HTTP status code 400. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ConflictException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-conflictexception/index.md) - Represents a request that conflicts with the current resource state and should be reported with HTTP status code 409. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ForbiddenException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-forbiddenexception/index.md) - Represents an understood request that the server refuses to perform and should be reported with HTTP status code 403. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.GoneException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-goneexception/index.md) - Represents a resource that is no longer available. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.HttpExceptionBase](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-httpexceptionbase/index.md) - Provides the common HTTP status and localization metadata carried by KamiSama HTTP exceptions. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.InvalidOperationHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-invalidoperationhttpexception/index.md) - Represents an invalid server operation that should be reported with HTTP status code 500. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotFoundException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notfoundexception/index.md) - Represents a request for an entity that could not be found. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotFoundException<TEntity>](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notfoundexception-tentity/index.md) - Represents a request for an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; that could not be found. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotImplementedHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notimplementedhttpexception/index.md) - Represents server functionality that is not implemented and should be reported with HTTP status code 501. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotSupportedHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notsupportedhttpexception/index.md) - Represents an unsupported server operation that should be reported with HTTP status code 500. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.PaymentRequiredException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-paymentrequiredexception/index.md) - Represents a request that requires payment and should be reported with HTTP status code 402. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ServiceUnavailableException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-serviceunavailableexception/index.md) - Represents a temporary service outage that should be reported with HTTP status code 503. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.UnAuthorizedException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-unauthorizedexception/index.md) - Represents an unauthenticated request that should be reported with HTTP status code 401. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.UnProcessableEntityException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-unprocessableentityexception/index.md) - Represents a semantically invalid request that should be reported with HTTP status code 422. Use it with the surrounding package APIs when composing application code.
