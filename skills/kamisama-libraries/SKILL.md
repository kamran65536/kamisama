---
name: kamisama-libraries
description: Use when Codex needs to answer questions, write code, review code, or generate examples against the KamiSama.Extensions libraries. This skill maps where to find the generated MkDocs API documentation and provides cached usage patterns for core extensions, repositories, chassis feature bases, web modules, dependency injection attributes, serialization helpers, external services, modules, logging, IranSystem, and testing helpers.
---

# Kamisama Libraries

Use the generated docs as the source of truth before answering or coding against KamiSama APIs. Prefer existing KamiSama types and extension methods over reimplementing similar utilities.

## Documentation Cache

Canonical online docs live under:

- `https://gitlab.com/kamran65536/KamiSama/-/tree/master/docs/content`
- API docs: `https://gitlab.com/kamran65536/KamiSama/-/tree/master/docs/content/api`

When working locally in this repository, use:

- `docs/content/index.md` for the package-family overview.
- `docs/content/api/index.md` for package descriptions and install commands.
- `docs/content/api/symbols.md` for symbol lookup.
- `docs/content/api/<package>/index.md` for package pages.
- `docs/content/api/<package>/<namespace>/<type>/index.md` for type pages.
- `docs/content/api/<package>/<namespace>/<type>/<member>.md` for methods, properties, fields, events, enum members, and operators.

When answering from GitLab, fetch and cache those same paths first. Start at `docs/content/api/index.md`, then open the package, type, and member page that matches the requested API. Do not rely on memory when an exact page exists.

## Usage Rules

- Mention exact package, namespace, type, and method names.
- Prefer async APIs when both sync and async versions exist.
- Prefer primary constructors in examples for derived features, repositories, modules, and test builders.
- Do not invent behavior that is not documented or visible in source.
- Use test snippets only when they clearly exercise the same API; otherwise write a small honest example or state that no concise standalone example is available.

## Cached Symbols

### Core Extensions

Use package `KamiSama.Extensions.Core`.

```csharp
using KamiSama.Extensions;
using KamiSama.Extensions.Paging;

var bytes = "hello".ToBytes();
var hex = bytes.ToHex();
var page = SearchModel.FromPage(1, 20);
var all = SearchModel.All;
var result = new[] { 1, 2, 3 }.AsQueryable().MakePaged(page);
```

`SearchModel` carries paging parameters. `PagedResult<T>` carries total count and page items, and can map item types through `ConvertTo` or `ConvertToAsync`.

### Repositories

Use `KamiSama.Repositories.Core` for contracts and in-memory repositories, `KamiSama.Repositories.Json` and `KamiSama.Repositories.Xml` for file-backed persistence, and EF/EF Core packages for DbContext-backed repositories.

```csharp
using KamiSama.Repositories.Json;

var repository = new JsonRepository<User>("users.json");
var user = await repository.FindAsync(x => x.Id == 1, cancellationToken);
```

```csharp
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public sealed class UserRepository(AppDbContext context)
    : GenericRepository<User, SearchModel, AppDbContext>(context), IUserRepository
{
    protected override IQueryable<User> ApplySearchModel(IQueryable<User> query, SearchModel searchModel)
        => query;
}
```

### Chassis Feature Bases

Use `KamiSama.Chassis.Commons.Features` for CRUD-style feature services and `KamiSama.Chassis.Commons.Abstractions` for contracts.

`GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>.AddAsync` runs this flow: duplicate check, request-to-entity conversion, repository add, entity-to-DTO conversion. Override `CheckDuplicateAsync`, `ConvertToEntity`, and `ConvertToDto`.

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.HttpExceptions;

public sealed class AddProductFeature(IProductRepository repository)
    : GenericAddFeature<AddProductRequest, IProductRepository, Product, ProductDto>(repository)
{
    protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)
    {
        if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
            throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
    }

    protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
        => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
```

Use `FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>` when several features share the same entity/repository mapping. Its nested `AddFeatureBase`, `UpdateFeatureBase`, `DeleteFeatureBase`, `ListFeatureBase`, `FindByIdFeatureBase`, and `ExistsByIdFeatureBase` classes avoid repeating generic arguments.

```csharp
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class AddProduct(IProductRepository repository) : AddFeatureBase(repository)
    {
        protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
            => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
```

### Web Modules

Use `KamiSama.Extensions.WebModules` to compose ASP.NET Core service registration and middleware setup.

```csharp
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
```

```csharp
public sealed class ProductsModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
        => services.AddScoped<IProductRepository, ProductRepository>();

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        app.MapGet("/products", () => Results.Ok());
        return Task.CompletedTask;
    }
}
```

Caveat: `ResponseCachingModule.ApplyConfigurationToAsync` currently throws `NotImplementedException`; do not present it as working middleware.

### Dependency Injection

Use `KamiSama.Extensions.DependencyInjection` for attribute-based service registration.

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;

services.AutoAddDependenciesFrom<Program>();
```

### Serialization

Use `KamiSama.Extensions.Json` and `KamiSama.Extensions.Xml` for serialization helpers.

```csharp
using KamiSama.Extensions;

var json = model.SerializeToJson();
var modelAgain = json.DeserializeFromJson<MyModel>();
```

### ProblemDetails And HTTP Exceptions

Use `KamiSama.Chassis.HttpExceptions` for API-safe errors and `KamiSama.Chassis.ProblemDetails` to convert exceptions to ASP.NET `ProblemDetails`.

```csharp
using KamiSama.Chassis.HttpExceptions;

throw new NotFoundException<Product>(id);
```

```csharp
services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options.UseDefaultProblemDetailsProvider());
```

### Miscellaneous

- `KamiSama.Extensions.NLog`: NLog layout renderers and encrypted archive compression.
- `KamiSama.IranSystem`: legacy Persian Iran System encoding conversion.
- `KamiSama.Extensions.RestSharp`: RestSharp registration and request helpers.
- `KamiSama.Testing.NSubstitute`: DI-first test builder that auto-creates substitutes for missing dependencies.

```csharp
using KamiSama.Testing.NSubstitute;

public sealed class ProductServiceTestsBuilder : TesterBuilderBase
{
    public ProductService Build() => BuildService<ProductService>();
}
```
