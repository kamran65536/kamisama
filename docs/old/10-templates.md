# 10. KamiSama.Templates
The KamiSama.Templates includes some interesting template projects which help you do code lesser, cleaner and faster.
All projects include a props.xml as central versioning and library management tool.
You can add props file like this (currently vistual studio does not show item templates):
```bash
dotnet new kamisama-props
```

## 10.1 Core Project
This project includes a core module scaffold with optional entities, repositories/database infrastructure, provider-specific DbContexts, and options.
```bash
dotnet new kamisama-core -n projectName
```

## 10.2 Repository Projects
This project provides classic repository, search model, dbcontext and .... The library will soon be upgraded to new handling model which is more cleaner and compact.
```bash
dotnet new kamisama-repos -n projectName
```
You can also create migration project using the following command:
```bash
dotnet new kamisama-repos-migration -n projectName
```

## 10.3 BoundedContext.Abstractions Project
Very compact and clean way to describe your beasiness as "Featrues" (Application Services). Each feature is set of related application services to one concept in the bounded context. See samples for more information.

```bash
dotnet new kamisama-boundedcontext-abstractions -n projectName
```

It is recommended to create one for all bounded context (domain abstractions) project.
You still need to run "Sync Namespaces" manually which will be fixed in next versions.

## 10.4 BoundedContext Project
Full implementation of how to use KamiSama.Chassis.Commons library efficiently.

```bash
dotnet new kamisama-boundedcontext -n projectName
```

## 10.5 Abstractions Project
Project template for shared abstractions with optional resources, data types, services, and exceptions folders.

```bash
dotnet new kamisama-abstractions -n projectName
```
