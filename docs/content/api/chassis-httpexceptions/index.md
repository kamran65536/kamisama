# KamiSama.Chassis.HttpExceptions

[Back to package index](../index.md)

Version: `10.0.10`

## Description

HTTP-oriented exception types with status codes, localization keys, and extra problem details. Use these exceptions to keep application errors consistent across ASP.NET Core APIs.

## Install

```shell
dotnet add package KamiSama.Chassis.HttpExceptions --version 10.0.10
```

## Namespaces

- [KamiSama.Chassis.HttpExceptions](kamisama-chassis-httpexceptions/index.md) (16 types)

## Types

- [KamiSama.Chassis.HttpExceptions.AlreadyExistsException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-alreadyexistsexception/index.md) - The entity already exists exception. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.AlreadyExistsException<TEntity>](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-alreadyexistsexception-tentity/index.md) - The entity already exists exception. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.BadRequestException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-badrequestexception/index.md) - The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing). Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ConflictException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-conflictexception/index.md) - Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ForbiddenException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-forbiddenexception/index.md) - The request contained valid data and was understood by the server, but the server is refusing action. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.GoneException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-goneexception/index.md) - Indicates that the resource requested was previously in use but is no longer available and will not be available again. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.HttpExceptionBase](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-httpexceptionbase/index.md) - base Exception class for all Janus Services. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.InvalidOperationHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-invalidoperationhttpexception/index.md) - Equivalant to `InvalidOperationException` but in the http mode. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotFoundException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notfoundexception/index.md) - Provides the `NotFoundException` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Chassis.HttpExceptions.NotFoundException<TEntity>](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notfoundexception-tentity/index.md) - Provides the `NotFoundException<TEntity>` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Chassis.HttpExceptions.NotImplementedHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notimplementedhttpexception/index.md) - he server either does not recognize the request method, or it lacks the ability to fulfil the request. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.NotSupportedHttpException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-notsupportedhttpexception/index.md) - he server either does not support the request method, or it lacks the ability to fulfil the request. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.PaymentRequiredException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-paymentrequiredexception/index.md) - The original intention was that this code might be used as part of some form of digital cash or micropayment scheme. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.ServiceUnavailableException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-serviceunavailableexception/index.md) - Thrown when some external service is not available. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.UnAuthorizedException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-unauthorizedexception/index.md) - Thrown when the operation requested is not authorized. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.HttpExceptions.UnProcessableEntityException](kamisama-chassis-httpexceptions/kamisama-chassis-httpexceptions-unprocessableentityexception/index.md) - The request was well-formed but was unable to be followed due to semantic errors. Use it with the surrounding package APIs when composing application code.
