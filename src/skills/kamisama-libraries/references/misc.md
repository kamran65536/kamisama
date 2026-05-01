# `KamiSama.Extensions.DependencyInjection`

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectAttributeBase`
Base attribute for convention-based DI registration.

Key public properties:

- `ServiceKey`
- `AllowMultiple`

### `ApplyInjection(IServiceCollection services, Type type)`
Registers the attributed type against either an explicit service type or an inferred interface.

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped]
public sealed class UserService : IUserService {}
```

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectAttribute`
General-purpose DI attribute where both service type and lifetime can be configured directly.

No public methods beyond inherited `ApplyInjection`.

```csharp
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInject(ServiceType = typeof(IUserService), Lifetime = ServiceLifetime.Scoped)]
public sealed class UserService : IUserService {}
```

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectScopedAttribute`
Scoped DI registration attribute.

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectScopedAttribute<TServiceType>`
Generic scoped DI registration attribute.

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectSingletonAttribute`
Singleton DI registration attribute.

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectSingletonAttribute<TService>`
Generic singleton DI registration attribute.

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectTransientAttribute`
Transient DI registration attribute.

## `KamiSama.Extensions.DependencyInjection`

### `AutoInjectTransientAttribute<TService>`
Generic transient DI registration attribute.

These attribute types expose constructors and inherited registration behavior only.

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton<ICacheService>]
public sealed class MemoryCacheService : ICacheService {}
```

## `KamiSama.Extensions.DependencyInjection`

### `ServiceCollectionExtensions`
Assembly-scanning helpers that register types decorated with `AutoInjectAttributeBase`.

### `AutoAddDependencies(this IServiceCollection services, params Assembly[]? assemblies)`
Scans assemblies and applies all auto-inject attributes.

### `AutoAddDependenciesFrom<TAssemblyType>(this IServiceCollection services)`
Scans the assembly containing one type.

### `AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>(this IServiceCollection services)`
Scans the assemblies containing two marker types.

```csharp
using KamiSama.Extensions.DependencyInjection;

services.AutoAddDependenciesFrom<Program>();
```

# `KamiSama.IranSystem`

## `KamiSama.IranSystem`

### `IranSystemEncoding`
Custom `Encoding` implementation for Iran System character encoding.

### `GetString(byte[] bytes)`
Decodes bytes into text.

### `GetBytes(string str)`
Encodes text into Iran System bytes.

### `GetByteCount`, `GetBytes(char[] ...)`, `GetCharCount`, `GetChars`, `GetMaxByteCount`, `GetMaxCharCount`
Standard `Encoding` overrides.

```csharp
using KamiSama.IranSystem;

var encoding = new IranSystemEncoding();
var bytes = encoding.GetBytes("سلام");
```

# `KamiSama.Extensions.NLog`

## `KamiSama.Extensions.NLog`

### `PasswordFunc`
Delegate used to calculate an archive password from the source and destination file names.

```csharp
using KamiSama.Extensions.NLog;

PasswordFunc password = (file, archive) => "secret";
```

## `KamiSama.Extensions.NLog`

### `EncryptedZipArchiveFileCompressor`
NLog-compatible file compressor that writes password-protected archives through SharpZipLib.

### `CompressFile(string fileName, string archiveFileName)`
Compresses a log file into a password-protected archive.

```csharp
using ICSharpCode.SharpZipLib.Zip;
using KamiSama.Extensions.NLog;

var compressor = new EncryptedZipArchiveFileCompressor((file, archive) => "secret", CompressionMethod.BZip2);
```

## `KamiSama.Extensions.NLog`

### `PersianDateLayoutRenderer`
NLog layout renderer named `persian-date`.

### `Format`
Controls the Persian date format string.

```csharp
// Use in NLog config as ${persian-date}
```

## `KamiSama.Extensions.NLog`

### `PersianLongDateLayoutRenderer`
NLog layout renderer named `persian-longDate`.

```csharp
// Use in NLog config as ${persian-longDate}
```

## `KamiSama.Extensions.NLog`

### `PersianShortDateLayoutRenderer`
NLog layout renderer named `persian-shortDate`.

```csharp
// Use in NLog config as ${persian-shortDate}
```

# `KamiSama.Testing.NSubstitute`

## `KamiSama.Testing.NSubstitute`

### `TesterBuilderBase`
Minimal DI-first test builder that auto-mocks missing constructor dependencies with NSubstitute.

### `AddOption<TOption>(Action<TOption> configure)`
Registers an options configuration.

### `AddScoped<TService>(params object[] param)`
Registers a scoped substitute.

### `AddSingleton<TService>()`
Registers a singleton substitute.

### `AddTransient<TService>()`
Registers a transient substitute.

### `For<T>()`
Resolves a service from the built scope.

### `BuildService<TService>()`
Builds the target service and auto-mocks missing constructor dependencies.

```csharp
using KamiSama.Testing.NSubstitute;

public sealed class UserServiceTestsBuilder : TesterBuilderBase {}
```
